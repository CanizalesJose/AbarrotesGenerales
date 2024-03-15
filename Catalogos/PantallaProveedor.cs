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
    public partial class PantallaProveedor : Form
    {
        static OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
        static OleDbCommand comando = new OleDbCommand(null, conexion);
        static OleDbDataReader reader;
        public PantallaProveedor()
        {
            InitializeComponent();
        }

        private void proveedorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.proveedorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.puntoVentaDataSet);

        }

        private void PantallaProveedor_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'puntoVentaDataSet.Proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.puntoVentaDataSet.Proveedor);
            labelFecha.Text = DateTime.Now.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BorrarDatos()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox1.Focus();
        }

        public Boolean BuscarRegistro()
        {
            //DataTable consulta = this.proveedorTableAdapter.consultaProveedor(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Proveedor_consultaProveedor(textBox1.Text);
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
                if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 || textBox3.Text.Length < 1 || textBox4.Text.Length < 1 || textBox5.Text.Length < 1)
                    throw new Exception("Todos los campos deben estar llenos.");
                if (BuscarRegistro())
                    throw new Exception("El registro ya existe.");

                //this.proveedorTableAdapter.InsertProveedor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Proveedor_InsertProveedor(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
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
                    throw new Exception("La clave de proveedor no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.proveedorTableAdapter.DeleteProveedor(textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Proveedor_DeleteProveedor(textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BorrarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1 || textBox3.Text.Length < 1 || textBox4.Text.Length < 1 || textBox5.Text.Length < 1)
                    throw new Exception("Todos los campos deben estar llenos.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.proveedorTableAdapter.UpdateProveedor(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Proveedor_UpdateProveedor(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox1.Text);
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
            //DataTable consulta = this.proveedorTableAdapter.consultaProveedor(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Proveedor_consultaProveedor(textBox1.Text);
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            if (consulta.Rows.Count > 0)
            {
                string nombre, direccion, correo, telefono;
                nombre = consulta.Rows[0]["nombreProveedor"].ToString();
                direccion = consulta.Rows[0]["direccionProveedor"].ToString();
                correo = consulta.Rows[0]["correoProveedor"].ToString();
                telefono = consulta.Rows[0]["telefonoProveedor"].ToString();
                textBox2.Text = nombre;
                textBox3.Text = direccion;
                textBox4.Text = correo;
                textBox5.Text = telefono;
            }
            else
            {
                textBox2.Text = string.Empty; 
                textBox3.Text = string.Empty; 
                textBox4.Text = string.Empty; 
                textBox5.Text = string.Empty;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 10)
            {
                textBox5.Text = textBox5.Text.Substring(0,10);
            }
        }
    }
}
