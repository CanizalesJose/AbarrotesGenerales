using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using AbarrotesGenerales.Auxiliares;

namespace AbarrotesGenerales.Reportes
{
    public partial class ReporteInventarioCategoria : Form
    {
        public ReporteInventarioCategoria()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
        }

        private void ReporteInventarioCategoria_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
            esconderDatos();

            //DataTable categorias = this.categoriaTableAdapter1.GetData();
            DataTable categorias = DBConsultas.EjecutarConsulta(DBConsultas.Categoria_GetData());
            comboBox1.ItemHeight = categorias.Rows.Count;

            for (int i = 0; i < categorias.Rows.Count; i++)
            {
                comboBox1.Items.Add(categorias.Rows[i]["idCategoria"].ToString());
            }
        }
        
        public void esconderDatos()
        {
            label2.Visible = false;
            textBoxNomCat.Visible = false;
            label3.Visible = false;
            textBoxTotal.Visible = false;
            labelFechaReporte.Visible = false;
            button3.Visible = false;
        }

        public void limpiar()
        {
            comboBox1.SelectedIndex = -1;
            esconderDatos();
            dataGridView1.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            //Ignorar
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBoxNomCat.Visible = true;
            //DataTable consulta = this.categoriaTableAdapter1.categoriaConsultaBase(comboBox1.Text);
            DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Categoria_categoriaConsultaBase(comboBox1.Text));
            if (consulta.Rows.Count > 0)
                textBoxNomCat.Text = consulta.Rows[0]["nombreCategoria"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == -1)
                    throw new Exception("Seleccionar una categoría.");
                dataGridView1.Rows.Clear();
                labelFechaReporte.Text = DateTime.Now.ToString();
                labelFechaReporte.Visible = true;
                label3.Visible = true;
                textBoxTotal.Visible = true;

                //DataTable consulta = this.inventarioTableAdapter1.ReporteInventarioCategoria(comboBox1.Text);
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Inventario_ReporteInventarioCategoria(comboBox1.Text));
                string idArticulo, nomArticulo, idProveedor, nomProveedor;
                int cantidad;
                double precio;
                double total = 0;
                //Llenar la tabla con los articulos del inventario de una categoria
                for (int i = 0; i < consulta.Rows.Count; i++)
                {
                    idArticulo = consulta.Rows[i]["idArticulo"].ToString();
                    nomArticulo = consulta.Rows[i]["nombreArticulo"].ToString();
                    idProveedor = consulta.Rows[i]["idProveedor"].ToString();
                    nomProveedor = consulta.Rows[i]["nombreProveedor"].ToString();
                    cantidad = int.Parse(consulta.Rows[i]["cantidadInventario"].ToString());
                    precio = double.Parse(consulta.Rows[i]["precioArticulo"].ToString());

                    total = total + (cantidad * precio);

                    dataGridView1.Rows.Add(idArticulo, nomArticulo, idProveedor, nomProveedor, cantidad, precio);
                }

                textBoxTotal.Text = total.ToString();
                button3.Visible = true;

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        public string GenerarCodigo(int noPag, int posTabla)
        {
            string codigoReporte = Properties.Resources.reporteinventario.ToString();

            //Reemplazar las variables del archivo
            codigoReporte = codigoReporte.Replace("@fecha", labelFechaReporte.Text);
            codigoReporte = codigoReporte.Replace("@idcat", comboBox1.Text);
            codigoReporte = codigoReporte.Replace("@nomcat", textBoxNomCat.Text);
            codigoReporte = codigoReporte.Replace("@total", "$ " + textBoxTotal.Text);
            codigoReporte = codigoReporte.Replace("@pag", "Pag. " + noPag);

            string filas = string.Empty;

            for (int i = posTabla; i < dataGridView1.Rows.Count; i++)
            {
                filas += "<tr>";

                filas += "<td>" + dataGridView1.Rows[i].Cells["idArticulo"].Value.ToString() + "</td>";
                filas += "<td>" + dataGridView1.Rows[i].Cells["nomArticulo"].Value.ToString() + "</td>";
                filas += "<td>" + dataGridView1.Rows[i].Cells["idProveedor"].Value.ToString() + "</td>";
                filas += "<td>" + dataGridView1.Rows[i].Cells["nomProveedor"].Value.ToString() + "</td>";
                filas += "<td>" + dataGridView1.Rows[i].Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + "$ " + dataGridView1.Rows[i].Cells["Precio"].Value.ToString() + "</td>";

                filas += "</tr>";

                if (i == (posTabla + 14))
                {
                    break;
                }
            }
            codigoReporte = codigoReporte.Replace("@filas", filas);

            return codigoReporte;
        }

        public void GenerarPDF()
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "RepoInventarioCat" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    int noPag = 1;

                    for (int i = 0; i < dataGridView1.Rows.Count; i = i + 15)
                    {
                        pdfDoc.NewPage();
                        pdfDoc.Add(new Phrase(""));
                        string codigoReporte = GenerarCodigo(noPag, i);

                        using (StringReader sr = new StringReader(codigoReporte))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }

                        noPag++;
                    }

                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("Archivo generado.");
                Process.Start(guardar.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenerarPDF();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Visible = false;
        }
    }
}
