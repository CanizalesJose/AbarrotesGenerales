using AbarrotesGenerales.Auxiliares;
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
    public partial class MantenimientoInventario : Form
    {
        public MantenimientoInventario()
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
            numericUpDownCant.Value = 0;
        }

        public void actualizarTabla()
        {
            datosInventario.Rows.Clear();
            //DataTable consulta = this.inventarioTableAdapter1.consultaInventarioGeneral();
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_consultaInventarioGeneral());
            
            if(consulta.Rows.Count > 0)
            {
                for (int i = 0; i < consulta.Rows.Count; i++)
                {
                    string idArticulo, idProv, nombreArticulo, nombreProveedor;
                    int cantidad;
                    decimal precio;

                    idArticulo = consulta.Rows[i]["idArticulo"].ToString();
                    idProv = consulta.Rows[i]["idProveedor"].ToString();
                    cantidad = int.Parse(consulta.Rows[i]["cantidadInventario"].ToString());
                    precio = decimal.Parse(consulta.Rows[i]["precioArticulo"].ToString());
                    nombreArticulo = consulta.Rows[i]["nombreArticulo"].ToString();
                    nombreProveedor = consulta.Rows[i]["nombreProveedor"].ToString();

                    datosInventario.Rows.Add(idArticulo, nombreArticulo, idProv, nombreProveedor, cantidad, precio);
                }
            }
            datosInventario.Refresh();
        }

        public Boolean buscarArticuloInventario()
        {
            try
            {
                //DataTable consulta = this.inventarioTableAdapter1.consultaInventarioTotal(textBox1.Text, textBox2.Text);
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_consultaInventarioTotal(textBoxCveArt.Text, textBoxCveProv.Text));

                if (consulta.Rows.Count > 0)
                    return true;
                else
                    return false;
            }catch (Exception)
            {
                return true;
            }

        }

        public Boolean buscarArticuloProveedor()
        {
            //DataTable consulta = this.articuloProveedorTableAdapter1.validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text));

            if (consulta.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void MantenimientoInventario_Load(object sender, EventArgs e)
        {
            actualizarTabla();
            labelArtProvValido.Visible = false;
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarArticuloInventario() == true)
                    throw new Exception("El registro ya esta registrado.");
                if (buscarArticuloProveedor() == false)
                    throw new Exception("El articulo no esta registrado en Articulo-Proveedor.");
                /*if (numericUpDownCant.Value < 0)
                    throw new Exception("La cantidad de articulos no puede ser menor a 0.");*/

                //this.inventarioTableAdapter1.InsertQuery(textBoxCveArt.Text, textBoxCveProv.Text,int.Parse(numericUpDownCant.Value.ToString()));
                DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(textBoxCveArt.Text, textBoxCveProv.Text, int.Parse(numericUpDownCant.Value.ToString())));
                MessageBox.Show("Registro agregado correctamente.");
            }catch(Exception ex)
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
                if (buscarArticuloInventario() == false)
                    throw new Exception("El articulo no esta en inventario.");
                if (buscarArticuloProveedor() == false)
                    throw new Exception("El articulo no esta registrado en Articulo-Proveedor.");

                //this.inventarioTableAdapter1.DeleteQuery(textBoxCveArt.Text,textBoxCveProv.Text);
                DBConsultas.EjecutarComando(DBConsultas.Inventario_DeleteQuery(textBoxCveArt.Text, textBoxCveProv.Text));
                MessageBox.Show("El registro ha sido eliminado.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actualizarTabla();
            borrarDatos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (buscarArticuloInventario() == false)
                    throw new Exception("El articulo no esta en inventario.");
                if (buscarArticuloProveedor() == false)
                    throw new Exception("El articulo no esta registrado en Articulo-Proveedor.");
                /*if (numericUpDownCant.Value < 0)
                    throw new Exception("La cantidad de articulos no puede ser menor a 0.");*/

                //this.inventarioTableAdapter1.UpdateQuery(int.Parse(numericUpDownCant.Value.ToString()), textBoxCveArt.Text, textBoxCveProv.Text);
                DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(int.Parse(numericUpDownCant.Value.ToString()), textBoxCveArt.Text, textBoxCveProv.Text));
                MessageBox.Show("Registro actualizado correctamente.");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            borrarDatos();
            actualizarTabla();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.articuloTableAdapter1.selectArticulo(textBoxCveArt.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_selectArticulo(textBoxCveArt.Text));

            if (consulta.Rows.Count == 1)
            {
                textBoxNomArt.Text = consulta.Rows[0]["nombreArticulo"].ToString();
            }
            else
            {
                textBoxNomArt.Text = string.Empty;
            }

            if (textBoxCveProv.Text.Length > 1)
            {
                //DataTable consultafinal = this.inventarioTableAdapter1.validarArticuloProveedorInventario(textBoxCveArt.Text,textBoxCveProv.Text);
                DataTable consultafinal = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                if (consultafinal.Rows.Count == 1)
                    numericUpDownCant.Value = int.Parse(consultafinal.Rows[0]["cantidadInventario"].ToString());
            }

            if (textBoxNomArt.Text != string.Empty && textBoxNomProv.Text != string.Empty)
            {
                labelArtProvValido.Visible = true;
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text));
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
                numericUpDownCant.Value = 0;
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.proveedorTableAdapter1.consultaProveedor(textBoxCveProv.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Proveedor_consultaProveedor(textBoxCveProv.Text));

            if (consulta.Rows.Count == 1)
                textBoxNomProv.Text = consulta.Rows[0][1].ToString();
            else
                textBoxNomProv.Text = string.Empty;

            if (textBoxCveArt.Text.Length > 1)
            {
                //DataTable consultafinal = this.inventarioTableAdapter1.validarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text);
                DataTable consultafinal = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(textBoxCveArt.Text, textBoxCveProv.Text));
                if (consultafinal.Rows.Count == 1)
                    numericUpDownCant.Value = int.Parse(consultafinal.Rows[0]["cantidadInventario"].ToString());
            }

            if (textBoxNomArt.Text != string.Empty && textBoxNomProv.Text != string.Empty)
            {
                labelArtProvValido.Visible = true;
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.ArticuloProveedor_validarArticuloProveedor(textBoxCveArt.Text, textBoxCveProv.Text));
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
                numericUpDownCant.Value = 0;
            }
        }
    }
}
