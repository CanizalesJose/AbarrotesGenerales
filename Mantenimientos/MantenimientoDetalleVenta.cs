using AbarrotesGenerales.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Mantenimientos
{
    public partial class MantenimientoDetalleVenta : Form
    {
        public MantenimientoDetalleVenta()
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
            textBoxCveArt.Text = string.Empty;
            textBoxCveProv.Text = string.Empty;
            textBoxNomArt.Text = string.Empty;
            textBoxNomProv.Text = string.Empty;
            numericUpDown1.Value = 0;
            textBoxCveArt.Focus();
        }

        public Boolean buscarArticulo()
        {
            //DataTable consulta = this.articuloTableAdapter1.selectArticulo(textBoxCveArt.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_selectArticulo(textBoxCveArt.Text));

            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }

        public Boolean buscarProveedor()
        {
            //DataTable consulta = this.proveedorTableAdapter1.consultaProveedor(textBoxCveProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Proveedor_consultaProveedor(textBoxCveProv.Text));

            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }

        public Boolean buscarArticuloProveedor()
        {
            //DataTable consulta = this.articuloProveedorTableAdapter1.validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text));

            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }

        public Boolean buscarVenta()
        {
            //DataTable consulta = this.ventaTableAdapter1.selectVentaBase(textBoxCveVent.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Venta_selectVentaBase(textBoxCveVent.Text));

            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }

        public Boolean buscarArticuloVenta()
        {
            //DataTable consulta = this.detalleVentaTableAdapter1.ConsultaVentaArticuloProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleVenta_ConsultarArticulosVentaProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text));

            if (consulta.Rows.Count == 1)
                return true;
            else
                return false;
        }


        public void actualizarTabla()
        {//PROBLEMAS
            tablaDatos.Rows.Clear();

            //DataTable consultaFinal = this.detalleVentaTableAdapter1.actualizarTablaDetalleVenta(textBoxCveVent.Text);
            DataTable consultaFinal = DBConsultas.EjecutarConsulta(DBConsultas.DetalleVenta_actualizarTablaDetalleVenta(textBoxCveVent.Text));

            int i=0;
            while (consultaFinal.Rows.Count != i)
            {
                string idArt, nomArt, idProv, nomProv;
                double precio;
                int cantidad;

                idArt = consultaFinal.Rows[i]["idArticulo"].ToString();
                idProv = consultaFinal.Rows[i]["idProveedor"].ToString();
                nomArt = consultaFinal.Rows[i]["nombreArticulo"].ToString();
                nomProv = consultaFinal.Rows[i]["nombreProveedor"].ToString();
                precio = double.Parse(consultaFinal.Rows[i]["precioArticulo"].ToString());
                cantidad = int.Parse(consultaFinal.Rows[i]["cantidadVenta"].ToString());
                tablaDatos.Rows.Add(idArt, nomArt,idProv, nomProv,precio,cantidad);
                i++;
                }
            tablaDatos.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarVenta() == false)
                    throw new Exception("La venta no existe.");
                if (buscarArticulo() == false)
                    throw new Exception("El articulo no existe.");
                if (buscarProveedor() == false)
                    throw new Exception("El proveedor no existe.");
                if (buscarArticuloProveedor() == false)
                    throw new Exception("El articulo no tiene el proveedor registrado.");
                if (buscarArticuloVenta())
                    throw new Exception("El registro ya existe.");

                //this.detalleVentaTableAdapter1.InsertQuery(textBoxCveVent.Text,textBoxCveArt.Text,textBoxCveProv.Text,int.Parse(numericUpDown1.Value.ToString()));
                DBConsultas.EjecutarComando(DBConsultas.DetalleVenta_InsertQuery(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text, int.Parse(numericUpDown1.Value.ToString())));

                //Restar los articulos de la venta al inventario
                //Consulta cuantos articulos habia en inventario antes de la venta
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                if (consulta.Rows.Count == 0)
                {
                    DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(textBoxCveArt.Text, textBoxCveProv.Text, 0));
                    consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                }
                //Calcula el resultado de lo que habia menos lo que se quita
                int resultadoInventarioVenta = int.Parse(consulta.Rows[0]["cantidadInventario"].ToString()) - int.Parse(numericUpDown1.Value.ToString());
                DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(resultadoInventarioVenta, textBoxCveArt.Text, textBoxCveProv.Text));

                MessageBox.Show("Registro agregado correctamente.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actualizarTabla();
            tablaDatos.Refresh();
            borrarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarVenta() == false)
                    throw new Exception("La venta no existe.");
                if (buscarArticuloVenta() == false)
                    throw new Exception("El registro no existe.");

                //this.detalleVentaTableAdapter1.DeleteQuery(textBoxCveVent.Text, textBoxCveArt.Text,textBoxCveProv.Text);

                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                if (consulta.Rows.Count == 0)
                {
                    DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(textBoxCveArt.Text, textBoxCveProv.Text, 0));
                    consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                }
                int cantidadInventario = int.Parse(consulta.Rows[0]["cantidadInventario"].ToString());
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleVenta_ConsultarArticulosVentaProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text));
                int cantidadVenta = int.Parse(consulta.Rows[0]["cantidadVenta"].ToString());
                int resultado = cantidadInventario + cantidadVenta;
                DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(resultado, textBoxCveArt.Text, textBoxCveProv.Text));

                DBConsultas.EjecutarComando(DBConsultas.DetalleVenta_DeleteQuery(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text));

                MessageBox.Show("El registro fue eliminado correctamente.");
                actualizarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarVenta() == false)
                    throw new Exception("La venta no existe.");
                if (buscarArticuloVenta() == false)
                    throw new Exception("El registro no existe.");
                //this.detalleVentaTableAdapter1.ActualizarDetalleVenta(int.Parse(numericUpDown1.Value.ToString()),textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text);

                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                if (consulta.Rows.Count == 0)
                {
                    DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(textBoxCveArt.Text, textBoxCveProv.Text, 0));
                    consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                }
                int cantidadInventario = int.Parse(consulta.Rows[0]["cantidadInventario"].ToString());
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleVenta_ConsultarArticulosVentaProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text));
                int cantidadVenta = int.Parse(consulta.Rows[0]["cantidadVenta"].ToString());
                int resultado = cantidadInventario + cantidadVenta;
                resultado = resultado - int.Parse(numericUpDown1.Value.ToString());
                DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(resultado, textBoxCveArt.Text, textBoxCveProv.Text));

                DBConsultas.EjecutarComando(DBConsultas.DetalleVenta_ActualizarDetalleVenta(int.Parse(numericUpDown1.Value.ToString()), textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text));
                
                MessageBox.Show("Registro actualizado correctamente.");
                actualizarTabla();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
        }

        private void textBoxCveVent_TextChanged(object sender, EventArgs e)
        {
            actualizarTabla();
        }

        private void textBoxCveArt_TextChanged(object sender, EventArgs e)
        {
            if (buscarArticulo())
            {
                //DataTable consulta = this.articuloTableAdapter1.selectArticulo(textBoxCveArt.Text);
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_selectArticulo(textBoxCveArt.Text));
                textBoxNomArt.Text = consulta.Rows[0]["nombreArticulo"].ToString();
            }
            else
                textBoxNomArt.Text = string.Empty;

            if (textBoxCveProv.Text.Length > 1)
            {
                //DataTable consulta = this.detalleVentaTableAdapter1.ConsultaVentaArticuloProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text);
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleVenta_ConsultarArticulosVentaProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text));

                if (consulta.Rows.Count > 0)
                    numericUpDown1.Value = int.Parse(consulta.Rows[0]["cantidadVenta"].ToString());
                else
                    numericUpDown1.Value = 0;
            }

            if (textBoxNomArt.Text != string.Empty && textBoxNomProv.Text != string.Empty)
            {
                labelArtProvValido.Visible = false;
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text));
                if (consulta.Rows.Count > 0)
                {
                    labelArtProvValido.Text = "Existe";
                    labelPrecio.Visible = true;
                    labelPrecio.Text = "$ " + consulta.Rows[0]["precioArticulo"].ToString();
                }
                else
                {
                    labelArtProvValido.Text = "No Existe";
                    labelPrecio.Visible = false;
                    labelPrecio.Text = string.Empty;
                }
            }
            else
            {
                labelArtProvValido.Visible = false;
                labelPrecio.Visible = false;
                labelPrecio.Text = string.Empty;
            }
        }

        private void textBoxCveProv_TextChanged(object sender, EventArgs e)
        {
            if (buscarProveedor())
            {
                //DataTable consulta = this.proveedorTableAdapter1.consultaProveedor(textBoxCveProv.Text);
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Proveedor_consultaProveedor(textBoxCveProv.Text));
                textBoxNomProv.Text = consulta.Rows[0]["nombreProveedor"].ToString();
            }
            else
                textBoxNomProv.Text = string.Empty;

            if (textBoxCveArt.Text.Length > 1)
            {
                //DataTable consulta = this.detalleVentaTableAdapter1.ConsultaVentaArticuloProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text);
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleVenta_ConsultarArticulosVentaProveedor(textBoxCveVent.Text, textBoxCveArt.Text, textBoxCveProv.Text));
                if (consulta.Rows.Count > 0)
                    numericUpDown1.Value = int.Parse(consulta.Rows[0]["cantidadVenta"].ToString());
                else 
                    numericUpDown1.Value = 0;
            }

            if (textBoxNomArt.Text != string.Empty && textBoxNomProv.Text != string.Empty)
            {
                labelArtProvValido.Visible = false;
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text));
                if (consulta.Rows.Count > 0)
                {
                    labelArtProvValido.Text = "Existe";
                    labelPrecio.Visible = true;
                    labelPrecio.Text = "$ " + consulta.Rows[0]["precioArticulo"].ToString();
                }
                else
                {
                    labelArtProvValido.Text = "No Existe";
                    labelPrecio.Visible = false;
                    labelPrecio.Text = string.Empty;
                }
            }
            else
            {
                labelArtProvValido.Visible = false;
                labelPrecio.Visible = false;
                labelPrecio.Text = string.Empty;
            }

        }

        private void MantenimientoDetalleVenta_Load(object sender, EventArgs e)
        {
            labelArtProvValido.Visible = false;
            labelFecha.Text = DateTime.Now.ToString();
            labelPrecio.Visible = false;
        }
    }
}
