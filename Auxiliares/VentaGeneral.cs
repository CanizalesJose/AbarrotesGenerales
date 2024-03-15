using AbarrotesGenerales.Consultas;
using AbarrotesGenerales.Mantenimientos;
using iTextSharp.tool.xml.html.table;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using AbarrotesGenerales.Auxiliares;
using System.Reflection.Emit;

namespace AbarrotesGenerales
{
    public partial class VentaGeneral : Form
    {
        //Abre y cierra la conexion con la base de datos
        static OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
        //Utiliza texto para ejecutar comandos SQL
        static OleDbCommand comando = new OleDbCommand(null, conexion);
        //Traduce las consultas SQL y almacena la carga para un DataTable
        static OleDbDataReader reader;
        
        public VentaGeneral()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Limpiar()
        {
            labelNomArt.Visible = false;
            labelNomProv.Visible = false;
            numericUpDown1.Enabled = false;
            comboBoxCveProv.Enabled = false;
            buttonAgregar.Enabled = false;
            buttonEliminar.Enabled = false;
            labelPrecio.Visible = false;
            comboBoxCveArt.SelectedIndex = -1;
            comboBoxCveProv.SelectedIndex = -1;
            numericUpDown1.Value = 1;

        }
        public void GenerarNuevaVenta()
        {
            Random rd = new Random();

            String nuevo = rd.Next(0, 999999999).ToString();
            int intentos = 0;
            conexion.Open();

            do
            {
                //DataTable consulta = this.ventaTableAdapter1.selectVentaBase(nuevo);
                comando.CommandText = DBConsultas.Venta_selectVentaBase(nuevo);
                reader = comando.ExecuteReader();
                DataTable consulta = new DataTable();
                consulta.Load(reader);

                if (consulta.Rows.Count > 0)
                {
                    nuevo = rd.Next(0, 999999999).ToString();
                }
                if (consulta.Rows.Count == 0)
                {
                    textBoxCveVent.Text = nuevo;
                    break;
                }
                intentos++;
            } while (intentos < 50);

            conexion.Close();
        }
        private void VentaGeneral_Load(object sender, EventArgs e)
        {
            labelTotal.Text = "";
            Limpiar();
            //Establecer la fecha
            labelFecha.Text = DateTime.Now.ToString("G");

            //Generar una clave de venta nueva y no usada
            GenerarNuevaVenta();
            //Consultar los articulos y colocarlos en el combobox
            //DataTable consultaArt = this.articuloTableAdapter1.GetData();
            conexion.Open();
            DataTable consultaArt = new DataTable();
            comando.CommandText = DBConsultas.Articulo_GetData();
            reader = comando.ExecuteReader();
            consultaArt.Load(reader);
            conexion.Close();
            for (int i = 0; consultaArt.Rows.Count > i; i++)
            {
                comboBoxCveArt.Items.Add(consultaArt.Rows[i]["idArticulo"].ToString());
            }
            
        }

        private void comboBoxCveArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelNomProv.Visible = false;
            numericUpDown1.Enabled = false;
            comboBoxCveProv.Enabled = false;
            labelPrecio.Visible = false;
            //Eliminar los proveedores anteriores y poner los del nuevo articulo
            comboBoxCveProv.Items.Clear();
            conexion.Open();
            try
            {
                
                if (comboBoxCveArt.SelectedIndex == -1)
                {
                    throw new Exception();
                }

                //DataTable consulta = this.proveedorTableAdapter1.ConsultaProveedoresArticulo(comboBoxCveArt.Text);
                DataTable consulta = new DataTable();
                comando.CommandText = DBConsultas.Proveedor_ConsultaProveedoresArticulo(comboBoxCveArt.Text);
                reader = comando.ExecuteReader();
                consulta.Load(reader);

                for (int i = 0; i < consulta.Rows.Count; i++)
                {
                    comboBoxCveProv.Items.Add(consulta.Rows[i]["idProveedor"].ToString());
                }

                comboBoxCveProv.Enabled = true;

                consulta.Clear();
                comando.CommandText = DBConsultas.Articulo_selectArticulo(comboBoxCveArt.Text);
                reader = comando.ExecuteReader();
                consulta.Load(reader);
                
                //consulta = this.articuloTableAdapter1.selectArticulo(comboBoxCveArt.Text);

                labelNomArt.Text = consulta.Rows[0]["nombreArticulo"].ToString();
                labelNomArt.Visible = true;

                
            }
            catch(Exception)
            {

            }
            conexion.Close();
        }

        private void comboBoxCveProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCveProv.SelectedIndex == -1)
                {
                    throw new Exception();
                }
                conexion.Open();
                DataTable consulta = new DataTable();
                comando.CommandText = DBConsultas.Proveedor_consultaProveedor(comboBoxCveProv.Text);
                reader = comando.ExecuteReader();
                consulta.Load(reader);
                //DataTable consulta = this.proveedorTableAdapter1.consultaProveedor(comboBoxCveProv.Text);
                labelNomProv.Text = consulta.Rows[0]["nombreProveedor"].ToString();

                consulta.Clear();
                comando.CommandText = DBConsultas.ArticuloProveedor_validarArticuloProveedor(comboBoxCveArt.Text, comboBoxCveProv.Text);
                reader = comando.ExecuteReader();
                consulta.Load(reader);
                //consulta = this.articuloProveedorTableAdapter1.validarArticuloProveedor(comboBoxCveArt.Text,comboBoxCveProv.Text);

                conexion.Close();

                labelPrecio.Text = consulta.Rows[0]["precioArticulo"].ToString();
                labelNomProv.Visible = true;
                numericUpDown1.Enabled = true;
                buttonAgregar.Enabled = true;
                buttonEliminar.Enabled = true;
                labelPrecio.Visible = true;
            }
            catch (Exception)
            {

            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        List<AuxiliarVenta> lista = new List<AuxiliarVenta>();

        public int contarArticulos(String arti, String prove)
        {    
            int contador = 0;
            foreach (AuxiliarVenta art in lista)
            {
                if (art.idArticulo == arti && art.idProveedor == prove)
                {
                    contador = contador + art.cantidad;
                }
            }
            return contador;
        }

        public void agregar()
        {
            Boolean existe = false;
            AuxiliarVenta item;
            int i;
            for (i = 0; i < lista.Count; i++)
            {
                item = lista[i];
                if (item.idArticulo == comboBoxCveArt.Text && item.idProveedor == comboBoxCveProv.Text)
                {
                    existe = true;
                    break;
                }
            }
            if (existe == false){
                lista.Add(new AuxiliarVenta(comboBoxCveArt.Text, comboBoxCveProv.Text, int.Parse(numericUpDown1.Value.ToString())));
            }
            if (existe == true)
            {
                lista[i].cantidad = lista[i].cantidad + int.Parse(numericUpDown1.Value.ToString());
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCveArt.SelectedIndex == -1)
                {
                    throw new Exception("Seleccionar un articulo.");
                }
                if (comboBoxCveProv.SelectedIndex == -1)
                {
                    throw new Exception("Seleccionar un proveedor.");
                }
                if (numericUpDown1.Value <= 0)
                {
                    throw new Exception("La cantidad no puede ser 0.");
                }
                //Si todo esta bien, agregar
                //Agregar al buffer que luego se usará para crear la venta
                agregar();

                //Agregar a la tabla visible
                ActualizarTabla();
                buttonEliminar.Enabled = true;
                Limpiar();

            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        public void ActualizarTabla()
        {
            tablaDatos.Rows.Clear();
            DataTable consulta = new DataTable();
            String nombreArt, nombreProv;
            double total = 0;
            double subtotal;

            conexion.Open();
            foreach (AuxiliarVenta item in lista) {
                //consulta = this.articuloTableAdapter1.selectArticulo(item.idArticulo);
                comando.CommandText = DBConsultas.Articulo_selectArticulo(item.idArticulo);
                reader = comando.ExecuteReader();
                consulta.Clear();
                consulta.Load(reader);
                nombreArt = consulta.Rows[0]["nombreArticulo"].ToString();

                //consulta = this.proveedorTableAdapter1.consultaProveedor(item.idProveedor);
                comando.CommandText = DBConsultas.Proveedor_consultaProveedor(item.idProveedor);
                reader = comando.ExecuteReader();
                consulta.Clear();
                consulta.Load(reader);
                nombreProv = consulta.Rows[0]["nombreProveedor"].ToString();

                //consulta = this.articuloProveedorTableAdapter1.validarArticuloProveedor(item.idArticulo, item.idProveedor);
                comando.CommandText = DBConsultas.ArticuloProveedor_validarArticuloProveedor(item.idArticulo, item.idProveedor);
                reader = comando.ExecuteReader();
                consulta.Clear();
                consulta.Load(reader);
                subtotal = item.cantidad * double.Parse(consulta.Rows[0]["precioArticulo"].ToString());

                total = total + subtotal;
                tablaDatos.Rows.Add(item.idArticulo, nombreArt, item.idProveedor, nombreProv, subtotal, item.cantidad);
            }
            conexion.Close();
            labelTotal.Text = total.ToString();
        }

        public void eliminar()
        {
            Boolean existe = false;
            AuxiliarVenta item;
            int i;
            for (i = 0; i < lista.Count; i++)
            {
                item = lista[i];
                if (item.idArticulo == comboBoxCveArt.Text && item.idProveedor == comboBoxCveProv.Text)
                {
                    existe = true;
                    break;
                }
            }
            if (existe == false)
            {
                throw new Exception("El articulo no se encuentra en la venta.");
            }
            if (existe == true)
            {
                lista.RemoveAt(i);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCveArt.SelectedIndex == -1)
                {
                    throw new Exception("Seleccionar un articulo");
                }
                if (comboBoxCveProv.SelectedIndex == -1)
                {
                    throw new Exception("Seleccionar un proveedor");
                }
                Boolean valido = false;
                foreach (AuxiliarVenta item in lista)
                {
                    if (item.idArticulo == comboBoxCveArt.Text && item.idProveedor == comboBoxCveProv.Text && item.cantidad == int.Parse(numericUpDown1.Value.ToString())) {
                        valido = true;
                    }
                }
                if (valido == false)
                {
                    throw new Exception("El articulo con la cantidad indicada no existe en la venta.");
                }
                //Si se puede identificar el articulo, entonces eliminarlo

                eliminar();
                tablaDatos.Rows.Clear();
                ActualizarTabla();
                MessageBox.Show("Articulo eliminado de la venta.");
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Limpiar();
            }
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (lista.Count == 0)
                {
                    throw new Exception("La venta esta vacía.");
                }
                
                //this.ventaTableAdapter1.InsertVenta(textBoxCveVent.Text, DateTime.Now);

                DBConsultas.EjecutarComando(DBConsultas.Venta_InsertVenta(textBoxCveVent.Text, DateTime.Now));

                foreach (AuxiliarVenta item in lista)
                {
                    //detalleVentaTableAdapter1.InsertQuery(textBoxCveVent.Text, item.idArticulo, item.idProveedor, item.cantidad);
                    DBConsultas.EjecutarComando(DBConsultas.DetalleVenta_InsertQuery(textBoxCveVent.Text, item.idArticulo, item.idProveedor, item.cantidad));

                    DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(item.idArticulo, item.idProveedor));
                    if (consulta.Rows.Count == 0)
                    {
                        DBConsultas.EjecutarComando(DBConsultas.Inventario_InsertQuery(item.idArticulo, item.idProveedor, item.cantidad));
                        consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ValidarArticuloProveedorInventario(item.idArticulo, item.idProveedor));
                        MessageBox.Show("El articulo no se encuentra en inventario. Se ha añadido automaticamente.");
                    }
                    int cantidadInventario = int.Parse(consulta.Rows[0]["cantidadInventario"].ToString());
                    int resultado = cantidadInventario - item.cantidad;
                    DBConsultas.EjecutarComando(DBConsultas.Inventario_UpdateQuery(resultado, item.idArticulo, item.idProveedor));
                }

                MessageBox.Show("Venta realizada con éxito.");
                lista.Clear();
                labelTotal.Text = "";
                tablaDatos.Rows.Clear();
                Limpiar();
                GenerarNuevaVenta();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (labelPrecio.Visible == true)
            {
                //DataTable consulta = this.articuloProveedorTableAdapter1.validarArticuloProveedor(comboBoxCveArt.Text, comboBoxCveProv.Text);
                DataTable consulta = new DataTable();
                conexion.Open();
                comando.CommandText = DBConsultas.ArticuloProveedor_validarArticuloProveedor(comboBoxCveArt.Text, comboBoxCveProv.Text);
                reader = comando.ExecuteReader();
                consulta.Clear();
                consulta.Load(reader);
                conexion.Close();

                double total = double.Parse(consulta.Rows[0]["precioArticulo"].ToString()) * int.Parse(numericUpDown1.Value.ToString());
                labelPrecio.Text = total.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MantenimientoAdeudo adeudo = new MantenimientoAdeudo();
            adeudo.Show();
        }
    }
}
