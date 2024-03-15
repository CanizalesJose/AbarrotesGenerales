using AbarrotesGenerales.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Catalogos
{
    public partial class PantallaCliente : Form
    {
        static OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
        static OleDbCommand comando = new OleDbCommand(null, conexion);
        static OleDbDataReader reader;
        public PantallaCliente()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.puntoVentaDataSet);

        }

        private void clienteBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.puntoVentaDataSet);

        }

        private void clienteBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.clienteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.puntoVentaDataSet);

        }

        private void PantallaCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'puntoVentaDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.puntoVentaDataSet.Cliente);
            comboBox1.SelectedIndex = 0;

        }

        public void BorrarDatos()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            textBox1.Focus();
        }

        public Boolean BuscarRegistro()
        {
            //DataTable consulta = this.clienteTableAdapter.consultaCliente(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Cliente_ConsultaCliente(textBox1.Text);
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            if (consulta.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public Boolean ValidarEstado()
        {
            if (comboBox1.SelectedIndex == 0)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de cliente no puede estar vacía.");
                if (textBox2.Text.Length < 1)
                    throw new Exception("El nombre del cliente no puede estar vacío.");
                if (textBox3.Text.Length < 1)
                    throw new Exception("El apellido del cliente no puede estar vacío.");
                if (textBox4.Text.Length < 1)
                    throw new Exception("Se debe proporcionar un teléfono para el cliente.");
                if (textBox5.Text.Length < 1)
                    throw new Exception("Se debe proporcionar una dirección para el cliente.");
                if (comboBox1.Text.Length < 1)
                    throw new Exception("El estado del cliente no puede estar vacío.");
                if (BuscarRegistro())
                    throw new Exception("El registro ya existe.");

                //this.clienteTableAdapter.InsertCliente(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, ValidarEstado());
                string eso = DBConsultas.Cliente_InsertCliente(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, ValidarEstado());
                conexion.Open();
                comando.CommandText = DBConsultas.Cliente_InsertCliente(textBox1.Text,textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, ValidarEstado());
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro insertado correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BorrarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de cliente no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.clienteTableAdapter.DeleteCliente(textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Cliente_DeleteCliente(textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BorrarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de cliente no puede estar vacía.");
                if (textBox2.Text.Length < 1)
                    throw new Exception("El nombre del cliente no puede estar vacío.");
                if (textBox3.Text.Length < 1)
                    throw new Exception("El apellido del cliente no puede estar vacío.");
                if (textBox4.Text.Length < 1)
                    throw new Exception("Se debe proporcionar un teléfono para el cliente.");
                if (textBox4.Text.Length > 10)
                    throw new Exception("El formato es de número de teléfono no corresponde. Introducir menos de 10 caracteres sin guiones.");
                if (textBox5.Text.Length < 1)
                    throw new Exception("Se debe proporcionar una dirección para el cliente.");
                if (comboBox1.Text.Length < 1)
                    throw new Exception("El estado del cliente no puede estar vacío.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.clienteTableAdapter.UpdateCliente(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, ValidarEstado(), textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Cliente_UpdateCliente(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, ValidarEstado(), textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro actualizado correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BorrarDatos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.clienteTableAdapter.consultaCliente(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Cliente_ConsultaCliente(textBox1.Text);
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            if (BuscarRegistro())
            {
                string nombre, apellido, direccion, telefono, estado;
                nombre = consulta.Rows[0]["nombreCliente"].ToString();
                apellido = consulta.Rows[0]["apellidoCliente"].ToString();
                telefono = consulta.Rows[0]["telefonoCliente"].ToString();
                direccion = consulta.Rows[0]["direccionCliente"].ToString();
                estado = consulta.Rows[0]["estadoCliente"].ToString();

                textBox2.Text = nombre;
                textBox3.Text = apellido;
                textBox4.Text = telefono;
                textBox5.Text = direccion;
                if (estado.Equals("True"))
                    comboBox1.SelectedIndex = 0;
                else
                    comboBox1.SelectedIndex = 1;

            }
            else
            {
                textBox2.Text = string.Empty; 
                textBox3.Text = string.Empty; 
                textBox4.Text = string.Empty; 
                textBox5.Text = string.Empty; 
                comboBox1.SelectedIndex = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString(); ;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 10)
            {
                textBox4.Text = textBox4.Text.Substring(0, 10);
            }
        }
    }
    
}
