using AbarrotesGenerales.Auxiliares;
using AbarrotesGenerales.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Mantenimientos
{
    public partial class MantenimientoAdeudo : Form
    {
        public MantenimientoAdeudo()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        public void borrarDatos()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.ResetText();
            numericUpDown1.Value = 0;
            textBox1.Focus();
        }

        public Boolean buscarAdeudo()
        {
            //DataTable consulta = this.adeudoTableAdapter1.consultaAdeudo(textBox1.Text);
            
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Adeudo_ConsultaAdeudo(textBox1.Text));

            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;   
        }
        public Boolean buscarCliente()
        {
            //DataTable consulta = this.clienteTableAdapter1.consultaCliente(textBox2.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Cliente_ConsultaCliente(textBox2.Text));
            
            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }
        public bool TieneAdeudos()
        {
            //DataTable consulta = this.adeudoTableAdapter1.TieneAdeudos(textBox2.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Adeudo_TieneAdeudos(textBox2.Text));

            if (consulta.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MantenimientoAdeudo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            labelFecha.Text = DateTime.Now.ToString();
        }
        public void ActualizarEstadoCliente()
        {
            if (TieneAdeudos())
            {
                //this.clienteTableAdapter1.ActualizarEstado(false, textBox2.Text);
                DBConsultas.EjecutarComando(DBConsultas.Cliente_ActualizarEstado(false, textBox2.Text));
            }
            else
            {
                //this.clienteTableAdapter1.ActualizarEstado(true, textBox2.Text);
                DBConsultas.EjecutarComando(DBConsultas.Cliente_ActualizarEstado(true, textBox2.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarAdeudo())
                    throw new Exception("El registro ya existe.");
                if (buscarCliente() == false)
                    throw new Exception("El cliente no esta registrado.");
                if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 || comboBox1.SelectedIndex == -1)
                    throw new Exception("Los campos no pueden estar vacíos.");
                if (numericUpDown1.Value < 0)
                    throw new Exception("El adeudo no puede ser menor a $0");
                Boolean estadoAdeudo;
                if (comboBox1.SelectedIndex == 0)
                    estadoAdeudo = false;
                else
                    estadoAdeudo = true;
                //Crear el adeudo
                //this.adeudoTableAdapter1.InsertQuery(textBox1.Text,dateTimePicker1.Value,textBox2.Text,estadoAdeudo,numericUpDown1.Value);
                DBConsultas.EjecutarComando(DBConsultas.Adeudo_InsertQuery(textBox1.Text, dateTimePicker1.Value, textBox2.Text, estadoAdeudo, double.Parse(numericUpDown1.Value.ToString())));

                MessageBox.Show("Registro insertado correctamente.");
                //Cambiar el estado del cliente si tiene adeudos pendientes
                ActualizarEstadoCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("El campo clave adeudo no puede estar vacío.");
                if (buscarAdeudo() == false)
                    throw new Exception("El registro no existe.");
                //Borrar el registro
                //this.adeudoTableAdapter1.DeleteQuery(textBox1.Text);
                DBConsultas.EjecutarComando(DBConsultas.Adeudo_DeleteQuery(textBox1.Text));

                MessageBox.Show("Registro eliminado correctamente.");

                //Actualizar el estado del cliente
                ActualizarEstadoCliente();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length<1)
                    throw new Exception("El campo clave adeudo no puede estar vacío.");
                if (buscarAdeudo() == false)
                    throw new Exception("El registro no existe.");
                if (textBox2.Text.Length < 1 || textBox3.Text.Length < 1 || comboBox1.SelectedIndex == -1)
                    throw new Exception("Los campos no pueden estar vacíos.");
                if (numericUpDown1.Value < 0)
                    throw new Exception("El adeudo no puede ser menor a $0");
                if (buscarCliente() == false)
                    throw new Exception("El cliente no esta registrado.");

                Boolean estadoAdeudo;
                if (comboBox1.SelectedIndex == 0)
                    estadoAdeudo = false;
                else
                    estadoAdeudo = true;


                //this.adeudoTableAdapter1.UpdateQuery(dateTimePicker1.Value,textBox2.Text,estadoAdeudo,numericUpDown1.Value,textBox1.Text);
                DBConsultas.EjecutarComando(DBConsultas.Adeudo_UpdateQuery(dateTimePicker1.Value, textBox2.Text, estadoAdeudo, double.Parse(numericUpDown1.Value.ToString()), textBox1.Text));

                MessageBox.Show("Registro actualizado correctamente.");
                //Actualizar el estado del cliente
                ActualizarEstadoCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.adeudoTableAdapter1.consultaAdeudo(textBox1.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Adeudo_ConsultaAdeudo(textBox1.Text));

            DateTime fecha;
            string cliente;
            Boolean estado;
            decimal cantidad;
            try
            {
                fecha = DateTime.Parse(consulta.Rows[0][1].ToString());
                cliente = consulta.Rows[0][2].ToString();
                estado = Boolean.Parse(consulta.Rows[0][3].ToString());
                cantidad = decimal.Parse(consulta.Rows[0][4].ToString());
                if (estado == false)
                    comboBox1.SelectedIndex = 0;
                else
                    comboBox1.SelectedIndex = 1;
                dateTimePicker1.Value = fecha;
                textBox2.Text = cliente;
                numericUpDown1.Value = cantidad;
            }
            catch (Exception)
            {
                dateTimePicker1.Value = DateTime.Now;
                textBox2.Text = string.Empty;
                comboBox1.SelectedIndex = -1;
                numericUpDown1.Value = 0;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.clienteTableAdapter1.consultaCliente(textBox2.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Cliente_ConsultaCliente(textBox2.Text));

            string nombre;
            try
            {
                nombre = consulta.Rows[0][1].ToString()+" "+consulta.Rows[0][2].ToString();
                textBox3.Text = nombre;
            }catch(Exception){
                textBox3.Text = string.Empty;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PantallaCliente cliente = new PantallaCliente();
            cliente.Show();
        }
    }
}
