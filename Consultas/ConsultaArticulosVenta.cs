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

namespace AbarrotesGenerales.Consultas
{
    public partial class ConsultaArticulosVenta : Form
    {
        public ConsultaArticulosVenta()
        {
            InitializeComponent();
        }

        private void ConsultaArticulosVenta_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
            labelFechaReporte.Visible = false;
            label3.Visible = false;
            textBoxTotal.Visible = false;

            //DataTable consulta = this.ventaTableAdapter1.GetData();
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Venta_GetData());
            for (int i = 0; i < consulta.Rows.Count; i++)
            {
                comboBoxIdVenta.Items.Add(consulta.Rows[i]["idVenta"].ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxIdVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.ventaTableAdapter1.selectVentaBase(comboBoxIdVenta.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Venta_selectVentaBase(comboBoxIdVenta.Text));

            if (consulta.Rows.Count > 0)
                textBoxFechaVenta.Text = consulta.Rows[0]["fechaVenta"].ToString();
            else
                textBoxFechaVenta.Text = string.Empty;

            labelFechaReporte.Text = DateTime.Now.ToString();
            label3.Visible = true;
            textBoxTotal.Visible = true;
            dataGridView1.Rows.Clear();

            try
            {
                //consulta = this.detalleVentaTableAdapter1.ConsultaArticulosVenta(comboBoxIdVenta.Text);
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleVenta_ConsultarArticulosVenta(comboBoxIdVenta.Text));
                string idArticulo, nomArticulo, idCategoria, nomCategoria, medida, idProveedor, nomProveedor;
                int cantidad;
                double precio;
                double total = 0;
                for (int i = 0; i < consulta.Rows.Count; i++)
                {
                    idArticulo = consulta.Rows[i]["idArticulo"].ToString();
                    nomArticulo = consulta.Rows[i]["nombreArticulo"].ToString();
                    idCategoria = consulta.Rows[i]["idCategoria"].ToString();
                    nomCategoria = consulta.Rows[i]["nombreCategoria"].ToString();
                    medida = consulta.Rows[i]["medidaArticulo"].ToString();
                    idProveedor = consulta.Rows[i]["idProveedor"].ToString();
                    nomProveedor = consulta.Rows[i]["nombreProveedor"].ToString();
                    cantidad = int.Parse(consulta.Rows[i]["cantidadVenta"].ToString());
                    precio = double.Parse(consulta.Rows[i]["precioArticulo"].ToString());

                    total = total + (precio * cantidad);

                    dataGridView1.Rows.Add(idArticulo, nomArticulo, idCategoria, nomCategoria, medida, idProveedor, nomProveedor, cantidad, precio);
                }
                textBoxTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelFechaReporte.Visible = false;
            label3.Visible = false;
            textBoxTotal.Visible = false;
            textBoxFechaVenta.Text = string.Empty;
            textBoxTotal.Text = string.Empty;
            dataGridView1.Rows.Clear();
            comboBoxIdVenta.SelectedIndex = -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }
    }
}
