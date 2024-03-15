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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AbarrotesGenerales.Catalogos
{
    public partial class PantallaEntrada : Form
    {
        static OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
        static OleDbCommand comando = new OleDbCommand(null, conexion);
        static OleDbDataReader reader;
        public PantallaEntrada()
        {
            InitializeComponent();
        }

        private void entradaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.entradaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.puntoVentaDataSet);

        }

        private void PantallaEntrada_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'puntoVentaDataSet.Entrada' Puede moverla o quitarla según sea necesario.
            this.entradaTableAdapter.Fill(this.puntoVentaDataSet.Entrada);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Boolean BuscarRegistro()
        {
            //DataTable consulta = this.entradaTableAdapter.consultaEntrada(textBox1.Text);
            DataTable consulta = new DataTable();
            comando.CommandText = DBConsultas.Entrada_consultaEntrada(textBox1.Text);
            conexion.Open();
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            if (consulta.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de entrada no puede estar vacía.");
                if (BuscarRegistro())
                    throw new Exception("El registro ya existe.");

                //this.entradaTableAdapter.InsertEntrada(textBox1.Text, dateTimePicker1.Value);
                conexion.Open();
                comando.CommandText = DBConsultas.Entrada_InsertarEntrada(textBox1.Text,dateTimePicker1.Value);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro insertado correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = string.Empty;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de entrada no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.entradaTableAdapter.DeleteEntrada(textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Entrada_DeleteEntrada(textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = string.Empty;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de entrada no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.entradaTableAdapter.UpdateEntrada(dateTimePicker1.Value, textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Entrada_UpdateEntrada(dateTimePicker1.Value, textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro actualizado correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = string.Empty;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.entradaTableAdapter.consultaEntrada(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Entrada_consultaEntrada(textBox1.Text);
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            string fecha;
            try
            {
                fecha = consulta.Rows[0]["fechaEntrada"].ToString();
                dateTimePicker1.Value = DateTime.Parse(fecha);
            }
            catch (Exception)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
        }
    }
}
