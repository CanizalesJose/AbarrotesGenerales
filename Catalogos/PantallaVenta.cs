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
    public partial class PantallaVenta : Form
    {
        static OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
        static OleDbCommand comando = new OleDbCommand(null, conexion);
        static OleDbDataReader reader;
        public PantallaVenta()
        {
            InitializeComponent();
        }

        private void ventaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ventaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.puntoVentaDataSet);

        }

        private void PantallaVenta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'puntoVentaDataSet.Venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.puntoVentaDataSet.Venta);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Boolean BuscarRegistro()
        {
            //DataTable consulta = this.ventaTableAdapter.selectVentaBase(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Venta_selectVentaBase(textBox1.Text);
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de venta no puede estar vacía.");
                if (BuscarRegistro())
                    throw new Exception("El registro ya existe.");

                //this.ventaTableAdapter.InsertVenta(textBox1.Text, dateTimePicker1.Value);
                conexion.Open();
                comando.CommandText = DBConsultas.Venta_InsertVenta(textBox1.Text, dateTimePicker1.Value);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro agregado correctamente.");
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
                    throw new Exception("La clave de venta no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.ventaTableAdapter.DeleteVenta(textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Venta_DeleteVenta(textBox1.Text);
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
                    throw new Exception("La clave de venta no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.ventaTableAdapter.UpdateVenta(dateTimePicker1.Value, textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Venta_UpdateVenta(dateTimePicker1.Value, textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Elemento actualizado correctamente");
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
            //DataTable consulta = this.ventaTableAdapter.selectVentaBase(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Venta_selectVentaBase(textBox1.Text);
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            string fecha;
            try
            {
                fecha = consulta.Rows[0]["fechaVenta"].ToString();
                dateTimePicker1.Value = DateTime.Parse(fecha);
            }
            catch (Exception)
            {
                dateTimePicker1.Value = DateTime.Now;
            }
        }
    }
}
