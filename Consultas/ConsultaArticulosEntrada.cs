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
    public partial class ConsultaArticulosEntrada : Form
    {
        public ConsultaArticulosEntrada()
        {
            InitializeComponent();
        }

        private void ConsultaArticulosEntrada_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
            borrar();

            //DataTable consulta = this.entradaTableAdapter1.GetData();
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Entrada_GetData());

            for (int i = 0; i < consulta.Rows.Count; i++)
            {
                comboBoxIdEntrada.Items.Add(consulta.Rows[i]["idEntrada"]);
            }
        }
        public void borrar()
        {
            labelFechaConsulta.Visible = false;
            label3.Visible = false;
            textBoxTotal.Visible = false;
            comboBoxIdEntrada.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            textBoxFechaEntrada.Text = string.Empty;
            textBoxTotal.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxIdVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.entradaTableAdapter1.consultaEntrada(comboBoxIdEntrada.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Entrada_consultaEntrada(comboBoxIdEntrada.Text));

            if (consulta.Rows.Count > 0)
                textBoxFechaEntrada.Text = consulta.Rows[0]["fechaEntrada"].ToString();

            dataGridView1.Rows.Clear();
            labelFechaConsulta.Text = DateTime.Now.ToString();
            labelFechaConsulta.Visible = true;
            label3.Visible = true;
            textBoxTotal.Visible = true;

            try
            {
                //consulta = this.detalleEntradaTableAdapter1.ConsultaArticulosEntrada(comboBoxIdEntrada.Text);
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.DetalleEntrada_ConsultaArticulosEntrada(comboBoxIdEntrada.Text));
                string idArticulo, nomArticulo, idCategoria, nomCategoria, medida, idProveedor, nomProveedor;
                int cantidad;
                double costo;
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
                    cantidad = int.Parse(consulta.Rows[i]["cantidadArticulo"].ToString());
                    costo = double.Parse(consulta.Rows[i]["costoArticulo"].ToString());

                    total = total + (costo * cantidad);

                    dataGridView1.Rows.Add(idArticulo, nomArticulo, idCategoria, nomCategoria, medida, idProveedor, nomProveedor, cantidad, costo);
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
            borrar();
        }
    }
}
