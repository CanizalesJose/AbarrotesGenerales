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
    public partial class ConsultaProveedoresArticulo : Form
    {
        public ConsultaProveedoresArticulo()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaProveedoresArticulo_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
            labelFechaReporte.Visible = false;

            //DataTable consulta = this.articuloTableAdapter1.GetData();
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_GetData());

            comboBox1.ItemHeight = consulta.Rows.Count;

            for (int i = 0; i < consulta.Rows.Count; i++)
            {
                comboBox1.Items.Add(consulta.Rows[i][0].ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable consulta = this.articuloTableAdapter1.ConsultaDatosArticulo(comboBox1.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Articulo_ConsultaDatosArticulo(comboBox1.Text));
            if(consulta.Rows.Count > 0)
            {
                textBoxNomArt.Text = consulta.Rows[0]["nombreArticulo"].ToString();
                textBoxidCat.Text = consulta.Rows[0]["idCategoria"].ToString();
                textBoxNomCat.Text = consulta.Rows[0]["nombreCategoria"].ToString();
            }

            try
            {
                dataGridView1.Rows.Clear();
                labelFechaReporte.Text = DateTime.Now.ToString();
                labelFechaReporte.Visible = true;

                //consulta = this.proveedorTableAdapter1.ConsultaProveedoresArticulo(comboBox1.Text);
                consulta = DBConsultas.EjecutarConsulta(DBConsultas.Proveedor_ConsultaProveedoresArticulo(comboBox1.Text));
                string idProveedor, nombreProveedor, direccion, telefono, correo;
                if (consulta.Rows.Count == 0 && comboBox1.SelectedIndex != -1)
                    throw new Exception("El articulo no tiene proveedores asignados.");
                for (int i = 0; i < consulta.Rows.Count; i++)
                {
                    idProveedor = consulta.Rows[i]["idProveedor"].ToString();
                    nombreProveedor = consulta.Rows[i]["nombreProveedor"].ToString();
                    direccion = consulta.Rows[i]["direccionProveedor"].ToString();
                    telefono = consulta.Rows[i]["telefonoProveedor"].ToString();
                    correo = consulta.Rows[i]["correoProveedor"].ToString();

                    dataGridView1.Rows.Add(idProveedor, nombreProveedor, direccion, telefono, correo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBoxNomArt.Text = string.Empty;
            textBoxidCat.Text = string.Empty;
            textBoxNomCat.Text = string.Empty;
            labelFechaReporte.Visible = false;
            dataGridView1.Rows.Clear();
        }
    }
}
