using AbarrotesGenerales.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Mantenimientos
{
    public partial class MantenimientoArticuloProveedor : Form
    {
        public MantenimientoArticuloProveedor()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        public void borrarDatos()
        {
            textBoxidArt.Text = string.Empty;
            textBoxNomArt.Text = string.Empty;
            textBoxNomCat.Text = string.Empty;
            textBoxMedida.Text = string.Empty;
            textBoxidProv.Text = string.Empty;
            textBoxNomProv.Text = string.Empty;
            numericUpDownPrecio.Value = 0;
            textBoxidArt.Focus();
        }

        public Boolean buscarDato()
        {
            //DataTable consulta = this.articuloProveedorTableAdapter1.validarArticuloProveedor(textBox1.Text,textBox5.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxidArt.Text, textBoxidProv.Text));
            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarDato())
                {
                    throw new Exception("El registro ya existe.");
                }
                if (textBoxNomArt.Text.Length < 1)
                {
                    throw new Exception("El articulo no existe.");
                }
                if (textBoxNomProv.Text.Length < 1)
                {
                    throw new Exception("El proveedor no existe.");
                }
                if (textBoxidArt.Text.Length < 1 || textBoxidProv.Text.Length < 1)
                {
                    throw new Exception("Los datos no pueden estar vacíos.");
                }
                if (numericUpDownPrecio.Value <= 0)
                    throw new Exception("El precio no puede ser menor a 1.");
                //this.articuloProveedorTableAdapter1.InsertQuery(textBoxidArt.Text, textBoxidProv.Text, numericUpDownPrecio.Value);
                DBConsultas.EjecutarComando(DBConsultas.ArticuloProveedor_InsertQuery(textBoxidArt.Text, textBoxidProv.Text, double.Parse(numericUpDownPrecio.Value.ToString())));

                MessageBox.Show("Registro agregado correctamente.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarDato() == false)
                    throw new Exception("El registro no existe.");
                //this.articuloProveedorTableAdapter1.DeleteQuery(textBoxidArt.Text, textBoxidProv.Text);
                DBConsultas.EjecutarComando(DBConsultas.ArticuloProveedor_DeleteQuery(textBoxidArt.Text, textBoxidProv.Text));

                MessageBox.Show("Registro eliminado correctamente.");
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
                if (buscarDato() == false)
                    throw new Exception("El registro no existe.");
                if (textBoxNomArt.Text.Length < 1)
                    throw new Exception("El articulo no existe.");
                if (textBoxNomProv.Text.Length < 1)
                    throw new Exception("El proveedor no existe.");
                if (textBoxidArt.Text.Length < 1 || textBoxidProv.Text.Length < 1)
                    throw new Exception("Los campos no pueden estar vacíos.");
                //this.articuloProveedorTableAdapter1.UpdateQuery(textBoxidArt.Text, textBoxidProv.Text, numericUpDownPrecio.Value, textBoxidArt.Text, textBoxidProv.Text);
                DBConsultas.EjecutarComando(DBConsultas.ArticuloProveedor_UpdateQuery(textBoxidArt.Text,textBoxidProv.Text, double.Parse(numericUpDownPrecio.Value.ToString())));

                MessageBox.Show("Registro actualizado correctamente.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.articuloTableAdapter1.selectArticuloCategoria(textBoxidArt.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_selecArticuloCategoria(textBoxidArt.Text));

            if (consulta.Rows.Count == 1)
            {
                textBoxNomArt.Text = consulta.Rows[0]["nombreArticulo"].ToString();
                textBoxNomCat.Text = consulta.Rows[0]["nombreCategoria"].ToString();
                textBoxMedida.Text = consulta.Rows[0]["medidaArticulo"].ToString();
            }
            else
            {
                textBoxNomArt.Text = string.Empty;
                textBoxNomCat.Text = string.Empty;
                textBoxMedida.Text = string.Empty;
            }

            if (textBoxidProv.Text.Length > 1)
            {
                //DataTable consultafinal = this.articuloProveedorTableAdapter1.validarArticuloProveedor(textBoxidArt.Text, textBoxidProv.Text);
                DataTable consultafinal = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxidArt.Text, textBoxidProv.Text));

                if (consultafinal.Rows.Count == 1)
                    numericUpDownPrecio.Value = decimal.Parse(consultafinal.Rows[0]["precioArticulo"].ToString());
                else
                    numericUpDownPrecio.Value = 0;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.proveedorTableAdapter1.consultaProveedor(textBoxidProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Proveedor_consultaProveedor(textBoxidProv.Text));

            if (consulta.Rows.Count == 1)
                textBoxNomProv.Text = consulta.Rows[0]["nombreProveedor"].ToString();
            else
                textBoxNomProv.Text = string.Empty;

            if (textBoxidArt.Text.Length > 1)
            {
                //DataTable consultafinal = this.articuloProveedorTableAdapter1.validarArticuloProveedor(textBoxidArt.Text, textBoxidProv.Text);
                DataTable consultafinal = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxidArt.Text, textBoxidProv.Text));

                if (consultafinal.Rows.Count == 1)
                    numericUpDownPrecio.Value = decimal.Parse(consultafinal.Rows[0]["precioArticulo"].ToString());
                else
                    numericUpDownPrecio.Value = 0;
            }
        }

        private void MantenimientoArticuloProveedor_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }
    }
}
