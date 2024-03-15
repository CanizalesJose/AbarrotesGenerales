using AbarrotesGenerales.Auxiliares;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AbarrotesGenerales.Mantenimientos
{
    public partial class MantenimientoDetalleEntrada : Form
    {
        public MantenimientoDetalleEntrada()
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
            textBoxIdArt.Text = string.Empty;
            textBoxIdProv.Text = string.Empty;
            numericCosto.Value = 0;
            numericCant.Value = 0;
            textBoxIdArt.Focus();
        }
        public void actualizarTabla()
        {
            datosEntrada.Rows.Clear();
            datosEntrada.Refresh();
            Boolean valido = false;
            //DataTable consulta = this.detalleEntradaTableAdapter1.consultaEntradaTotal(textBox1.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleEntrada_consultaEntradaTotal(textBoxIdEnt.Text));
            try
            {
                int cuenta, i;
                cuenta = consulta.Rows.Count;
                i = 0;
                while (i!=cuenta)
                {
                    string idArticulo, idProveedor, nombreArticulo;
                    Int32 cantidad;
                    double costo;

                    idArticulo = consulta.Rows[i]["idArticulo"].ToString();
                    idProveedor = consulta.Rows[i]["idProveedor"].ToString();
                    nombreArticulo = consulta.Rows[i]["nombreArticulo"].ToString();
                    cantidad = Int32.Parse(consulta.Rows[i]["cantidadArticulo"].ToString());
                    costo = double.Parse(consulta.Rows[i]["costoArticulo"].ToString());

                    datosEntrada.Rows.Add(idArticulo, idProveedor, nombreArticulo, cantidad, costo);
                    valido = true;
                    i++;
                }
            }
            catch (Exception)
            {
                if (valido == false)
                {
                    datosEntrada.Rows.Clear();
                    datosEntrada.Refresh();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            actualizarTabla();
        }

        public Boolean buscarArticulo()
        {
            //DataTable consulta = this.articuloProveedorTableAdapter1.validarArticuloProveedor(textBoxIdArt.Text, textBoxIdProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxIdArt.Text, textBoxIdProv.Text));

            if (consulta.Rows.Count == 0)
                return false;
            else
                return true;
        }
        public Boolean buscarDato()
        {
            //DataTable consulta = this.detalleEntradaTableAdapter1.consultaEntrada(textBoxIdEnt.Text, textBoxIdArt.Text,textBoxIdProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleEntrada_consultaEntrada(textBoxIdEnt.Text, textBoxIdArt.Text, textBoxIdProv.Text)); 

            if (consulta.Rows.Count == 0)
                return false;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarDato())
                    throw new Exception("El registro ya existe.");
                if (textBoxIdEnt.Text.Length < 1 || textBoxIdArt.Text.Length < 1 || textBoxIdProv.Text.Length < 1 || numericCosto.Value < 1)
                    throw new Exception("Los campos no pueden estar vacíos.");
                if (buscarArticulo() == false)
                    throw new Exception("El articulo no tiene asignado un proveedor.");

                //this.detalleEntradaTableAdapter1.InsertQuery(textBoxIdEnt.Text, textBoxIdArt.Text,textBoxIdProv.Text, numericCosto.Value, Int32.Parse(numericCant.Value.ToString()));
                DBConsultas.EjecutarComando(DBConsultas.DetalleEntrada_InsertQuery(textBoxIdEnt.Text, textBoxIdArt.Text, textBoxIdProv.Text, double.Parse(numericCosto.Value.ToString()),int.Parse(numericCant.Value.ToString())));

                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxIdArt.Text, textBoxIdProv.Text));
                if (consulta.Rows.Count == 0)
                {
                    DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(textBoxIdArt.Text, textBoxIdProv.Text, 0));
                    consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxIdArt.Text, textBoxIdProv.Text));
                }
                int cantidadInventario = int.Parse(consulta.Rows[0]["cantidadInventario"].ToString());
                int resultado = int.Parse(numericCant.Value.ToString()) + cantidadInventario;
                DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(resultado, textBoxIdArt.Text, textBoxIdProv.Text));

                MessageBox.Show("Registro agregado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
            actualizarTabla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarDato() == false)
                    throw new Exception("El registro no existe.");
                //this.detalleEntradaTableAdapter1.DeleteQuery(textBoxIdEnt.Text,textBoxIdArt.Text, textBoxIdProv.Text);

                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxIdArt.Text, textBoxIdProv.Text));
                if (consulta.Rows.Count == 0)
                {
                    DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(textBoxIdArt.Text, textBoxIdProv.Text, 0));
                    consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxIdArt.Text, textBoxIdProv.Text));
                }
                int cantidadInventario = int.Parse(consulta.Rows[0]["cantidadInventario"].ToString());
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleEntrada_consultaEntrada(textBoxIdEnt.Text, textBoxIdArt.Text, textBoxIdProv.Text));
                int cantidadEntrada = int.Parse(consulta.Rows[0]["cantidadArticulo"].ToString());
                int resultado = cantidadInventario - cantidadEntrada;
                DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(resultado, textBoxIdArt.Text, textBoxIdProv.Text));

                DBConsultas.EjecutarComando(DBConsultas.DetalleEntrada_DeleteQuery(textBoxIdEnt.Text, textBoxIdArt.Text, textBoxIdProv.Text));

                MessageBox.Show("Registro eliminado correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
            actualizarTabla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
                if (buscarDato() == false)
                    throw new Exception("El registro no existe.");
                if (textBoxIdEnt.Text.Length < 1 || textBoxIdArt.Text.Length < 1 || textBoxIdProv.Text.Length < 1 || numericCosto.Value < 1)
                    throw new Exception("Los campos no pueden estar vacíos.");
                if (buscarArticulo() == false)
                    throw new Exception("El articulo no tiene asignado un proveedor.");
                //this.detalleEntradaTableAdapter1.UpdateQuery(numericCosto.Value,Int32.Parse(numericCant.Value.ToString()),textBoxIdEnt.Text, textBoxIdArt.Text, textBoxIdProv.Text);

                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxIdArt.Text, textBoxIdProv.Text));
                if (consulta.Rows.Count == 0)
                {
                    DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(textBoxIdArt.Text, textBoxIdProv.Text, 0));
                    consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxIdArt.Text, textBoxIdProv.Text));
                }
                int cantidadInventario = int.Parse(consulta.Rows[0]["cantidadInventario"].ToString());
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleEntrada_consultaEntrada(textBoxIdEnt.Text, textBoxIdArt.Text, textBoxIdProv.Text));
                int cantidadEntrada = int.Parse(consulta.Rows[0]["cantidadArticulo"].ToString());
                int resultado = cantidadInventario - cantidadEntrada;
                resultado = resultado + int.Parse(numericCant.Value.ToString());
                DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(resultado, textBoxIdArt.Text, textBoxIdProv.Text));

                DBConsultas.EjecutarComando(DBConsultas.DetalleEntrada_UpdateQuery(double.Parse(numericCosto.Value.ToString()), int.Parse(numericCant.Value.ToString()), textBoxIdEnt.Text, textBoxIdArt.Text, textBoxIdProv.Text));

                MessageBox.Show("Actualizado correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
            actualizarTabla();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                actualizarTabla();
            }
        }

        private void textBoxIdArt_TextChanged(object sender, EventArgs e)
        {
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_selectArticulo(textBoxIdArt.Text));
            if (consulta.Rows.Count > 0)
            {
                textBoxNomArt.Text = consulta.Rows[0]["nombreArticulo"].ToString();
            }
            else
            {
                textBoxNomArt.Text = string.Empty;
            }
            //Si se han escrito articulo y proveedor, avisar si estan disponibles
            if (textBoxNomArt.Text != string.Empty && textBoxNomProv.Text != string.Empty)
            {
                labelArtProvValido.Visible = true;
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxIdArt.Text, textBoxIdProv.Text));
                if (consulta.Rows.Count > 0)
                {
                    labelArtProvValido.Text = "Existe";
                }
                else
                {
                    labelArtProvValido.Text = "No Existe";
                }
            }
            else
            {
                labelArtProvValido.Visible = false;
            }
        }

        private void textBoxIdProv_TextChanged(object sender, EventArgs e)
        {
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Proveedor_consultaProveedor(textBoxIdProv.Text));
            if (consulta.Rows.Count > 0)
            {
                textBoxNomProv.Text = consulta.Rows[0]["nombreProveedor"].ToString();
            }
            else
            {
                textBoxNomProv.Text = string.Empty;
            }
            //Avisar si la combinacion esta disponible
            if (textBoxNomArt.Text != string.Empty && textBoxNomProv.Text != string.Empty)
            {
                labelArtProvValido.Visible = true;
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxIdArt.Text, textBoxIdProv.Text));
                if (consulta.Rows.Count > 0)
                {
                    labelArtProvValido.Text = "Existe";
                }
                else
                {
                    labelArtProvValido.Text = "No Existe";
                }
            }
            else
            {
                labelArtProvValido.Visible = false;
            }
        }

        private void MantenimientoDetalleEntrada_Load(object sender, EventArgs e)
        {
            labelArtProvValido.Visible = false;
        }
    }


}
