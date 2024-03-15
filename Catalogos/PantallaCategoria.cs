using AbarrotesGenerales.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Catalogos
{
    public partial class PantallaCategoria : Form
    {
        static OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
        static OleDbCommand comando = new OleDbCommand(null, conexion);
        static OleDbDataReader reader;
        public PantallaCategoria()
        {
            InitializeComponent();
        }

        private void categoriaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.puntoVentaDataSet);

        }

        private void PantallaCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'puntoVentaDataSet.Categoria' Puede moverla o quitarla según sea necesario.
            this.categoriaTableAdapter.Fill(this.puntoVentaDataSet.Categoria);
            labelFecha.Text = DateTime.Now.ToString();

        }
        public void borrarTexto()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox1.Focus();
        }

        public Boolean BuscarRegistro()
        {
            //DataTable consulta = this.categoriaTableAdapter.categoriaConsultaBase(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Categoria_categoriaConsultaBase(textBox1.Text);
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
                    throw new Exception("La clave de categoria no puede estar vacía.");
                if (textBox2.Text.Length < 1)
                    throw new Exception("El nombre de categoría no puede estar vacío.");
                if (textBox3.Text.Length < 1)
                    throw new Exception("La descripción no puede estar vacía.");
                if (BuscarRegistro())
                    throw new Exception("El registro ya existe.");
                
                //this.categoriaTableAdapter.InsertCategoria(textBox1.Text, textBox2.Text, textBox3.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Categoria_InsertCategoria(textBox1.Text, textBox2.Text, textBox3.Text);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro insertado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarTexto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de categoría no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //this.categoriaTableAdapter.DeleteCategoria(textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Categoria_DeleteCategoria(textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro eliminado Correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarTexto();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length < 1)
                    throw new Exception("La clave de categoria no puede estar vacía.");
                if (textBox2.Text.Length < 1)
                    throw new Exception("El nombre de categoría no puede estar vacío.");
                if (textBox3.Text.Length < 1)
                    throw new Exception("La descripción no puede estar vacía.");
                if (BuscarRegistro() == false)
                    throw new Exception("El registro no existe.");

                //categoriaTableAdapter.UpdateCategoria(textBox2.Text, textBox3.Text, textBox1.Text);
                conexion.Open();
                comando.CommandText = DBConsultas.Categoria_UpdateCategoria(textBox2.Text, textBox3.Text, textBox1.Text);
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Registro actualizado correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarTexto();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.categoriaTableAdapter.categoriaConsultaBase(textBox1.Text);
            DataTable consulta = new DataTable();
            conexion.Open();
            comando.CommandText = DBConsultas.Categoria_categoriaConsultaBase(textBox1.Text);
            reader = comando.ExecuteReader();
            consulta.Clear();
            consulta.Load(reader);
            conexion.Close();

            if (BuscarRegistro())
            {
                string nombre, descripcion;
                nombre = consulta.Rows[0]["nombreCategoria"].ToString();
                descripcion = consulta.Rows[0]["descripcionCategoria"].ToString();
                textBox2.Text = nombre;
                textBox3.Text = descripcion;
            }
            else
            {
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
        
        }
    }
}
