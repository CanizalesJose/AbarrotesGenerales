using AbarrotesGenerales.Auxiliares;
using AbarrotesGenerales.PuntoVentaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Mantenimientos
{
    public partial class MantenimientoArticulo : Form
    {
        public static ArticuloTableAdapter adaptadorArticulos = new ArticuloTableAdapter();
        public MantenimientoArticulo()
        {
            InitializeComponent();
        }
        
        public void borrarDatos()
        {
            textBoxIdArt.Text = string.Empty;
            textBoxIdCat.Text = string.Empty;
            textBoxNomCat.Text = string.Empty;
            textBoxNomArt.Text = string.Empty;
            textBoxUnMed.Text = string.Empty;
            textBoxIdArt.Focus();
        }

        public Boolean buscarDato()
        {
            //DataTable consulta = this.articuloTableAdapter1.selectArticulo(textBox1.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_selectArticulo(textBoxIdArt.Text));

            if (consulta.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarDato())
                    throw new Exception("El registro ya existe.");
                if (textBoxNomCat.Text.Length < 1)
                {
                    throw new Exception("La categoria no existe. Dar de alta una con dicha clave primero.");
                }
                if (textBoxIdArt.Text.Length < 1 | textBoxIdCat.Text.Length < 1 | textBoxNomArt.Text.Length < 1 | textBoxUnMed.Text.Length < 1)
                {
                    throw new Exception("Los campos no pueden estar vacíos.");
                }
                //this.articuloTableAdapter1.InsertarArticulo(textBox1.Text, textBox2.Text, textBox4.Text, textBox4.Text);
                DBConsultas.EjecutarComando(DBConsultas.Articulo_InsertarArticulo(textBoxIdArt.Text, textBoxIdCat.Text, textBoxNomArt.Text, textBoxUnMed.Text));

                MessageBox.Show("Registro agregado correctamente.");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.categoriaTableAdapter1.categoriaConsultaBase(textBox2.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Categoria_categoriaConsultaBase(textBoxIdCat.Text));
            string nombre;

            try
            {
                nombre = consulta.Rows[0]["nombreCategoria"].ToString();
                textBoxNomCat.Text = nombre;
            }
            catch(Exception)
            {
                textBoxNomCat.Text = string.Empty;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarDato() == false)
                    throw new Exception("El registro no existe.");
                if (textBoxIdArt.Text.Length < 1)
                {
                    throw new Exception("La clave de articulo no puede estar vacía.");
                }
                MessageBox.Show("Registro eliminado correctamente.");
                //this.articuloTableAdapter1.DeleteArticulo(textBox1.Text);
                DBConsultas.EjecutarComando(DBConsultas.Articulo_DeleteArticulo(textBoxIdArt.Text));

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarDato() == false)
                    throw new Exception("El registro no existe.");
                if (textBoxNomCat.Text.Length < 1)
                {
                    throw new Exception("La categoria no existe. Dar de alta una con dicha clave primero.");
                }
                if (textBoxIdArt.Text.Length < 1 | textBoxIdCat.Text.Length < 1 | textBoxNomArt.Text.Length < 1 | textBoxUnMed.Text.Length < 1)
                {
                    throw new Exception("Los campos no pueden estar vacíos.");
                }
                //this.articuloTableAdapter1.UpdateArticulos(textBox1.Text, textBox2.Text,textBox4.Text,textBox5.Text,textBox1.Text);
                DBConsultas.EjecutarComando(DBConsultas.Articulo_UpdateArticulo(textBoxIdArt.Text, textBoxIdCat.Text,textBoxNomArt.Text,textBoxUnMed.Text));

                MessageBox.Show("Registro actualizado correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.articuloTableAdapter1.selectArticulo(textBoxIdArt.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_selectArticulo(textBoxIdArt.Text));
            string categoria, nombre, medida;
            try
            {
                categoria = consulta.Rows[0]["idCategoria"].ToString();
                nombre = consulta.Rows[0]["nombreArticulo"].ToString();
                medida = consulta.Rows[0]["medidaArticulo"].ToString();

                textBoxIdCat.Text = categoria;
                textBoxNomArt.Text = nombre;
                textBoxUnMed.Text = medida;

            }catch(Exception)
            {
                textBoxIdCat.Text = string.Empty;
                textBoxNomCat.Text = string.Empty;
                textBoxNomArt.Text = string.Empty;
                textBoxUnMed.Text = string.Empty;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantenimientoArticulo_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }
    }
}
