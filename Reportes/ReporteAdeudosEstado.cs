using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbarrotesGenerales.Auxiliares;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.intern;
using iTextSharp.tool.xml;
using iTextSharp.xmp;
using Org.BouncyCastle.Asn1.X509;

namespace AbarrotesGenerales.Reportes
{
    public partial class ReporteAdeudosEstado : Form
    {
        public ReporteAdeudosEstado()
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

        private void ReporteAdeudosEstado_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString("");
            comboBox1.SelectedIndex = -1;
            labelFechaReporte.Visible = false;
            label2.Visible = false; labelTotal.Visible = false;
            button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                datos.Rows.Clear();
                labelTotal.Text = "0";
                Boolean estado;
                if (comboBox1.SelectedIndex == -1)
                    throw new Exception("Seleccionar un estado.");
                if (comboBox1.SelectedIndex == 0)
                    estado = false;
                else
                    estado = true;
                //DataTable consulta = this.adeudoTableAdapter1.ReporEstado(estado);
                DataTable consulta = DBConsultas.EjecutarConsulta(DBConsultas.Adeudo_ReporEstado(estado));

                if (consulta.Rows.Count > 0)
                {
                    string idAdeudo, fecha, idCliente, nombre, apellido, telefono;
                    double monto;

                    for (int i = 0; i < consulta.Rows.Count; i++)
                    {
                        idAdeudo = consulta.Rows[i]["idAdeudo"].ToString();
                        fecha = consulta.Rows[i]["fechaAdeudo"].ToString();
                        idCliente = consulta.Rows[i]["idCliente"].ToString();
                        nombre = consulta.Rows[i]["nombreCliente"].ToString();
                        apellido = consulta.Rows[i]["apellidoCliente"].ToString();
                        telefono = consulta.Rows[i]["telefonoCliente"].ToString();
                        monto = Double.Parse(consulta.Rows[i]["cantidadAdeudo"].ToString());

                        datos.Rows.Add(idAdeudo, fecha, idCliente, nombre, apellido, telefono, monto);
                    }
                    consulta = DBConsultas.EjecutarConsulta(DBConsultas.Adeudo_ConsultaTotalAdeudo(estado));
                    labelTotal.Text = consulta.Rows[0]["total"].ToString();
                    label2.Visible = true; labelTotal.Visible = true;
                    labelFechaReporte.Text = DateTime.Now.ToString(); labelFechaReporte.Visible = true;
                }
                button3.Visible = true;

            }
            catch (Exception ex)
            {
                datos.Rows.Clear();
                MessageBox.Show(ex.Message);
                labelFechaReporte.Visible = false;
                label2.Visible = false; labelTotal.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            labelFechaReporte.Visible = false;
            label2.Visible = false; labelTotal.Visible = false;
            datos.Rows.Clear();
            button3.Visible = false;
        }

        public string GenerarCodigoHTML(int noPag, int posTabla)
        {
            string codigoReporte = Properties.Resources.reporteadeudos.ToString();

            codigoReporte = codigoReporte.Replace("@fecha", labelFechaReporte.Text);
            codigoReporte = codigoReporte.Replace("@estado", comboBox1.Text);
            codigoReporte = codigoReporte.Replace("@total", "$ " + labelTotal.Text);
            codigoReporte = codigoReporte.Replace("@pag", "Pag. " + noPag);

            string filas = string.Empty;

            for (int i = posTabla; i < datos.Rows.Count; i++)
            {
                filas += "<tr>";

                filas += "<td>" + datos.Rows[i].Cells["idAdeudo"].Value.ToString() + "</td>";
                filas += "<td>" + datos.Rows[i].Cells["fechaAdeudo"].Value.ToString() + "</td>";
                filas += "<td>" + datos.Rows[i].Cells["idCliente"].Value.ToString() + "</td>";
                filas += "<td>" + datos.Rows[i].Cells["Nombre"].Value.ToString() + "</td>";
                filas += "<td>" + datos.Rows[i].Cells["Apellido"].Value.ToString() + "</td>";
                filas += "<td>" + datos.Rows[i].Cells["Telefono"].Value.ToString() + "</td>";
                filas += "<td>" + "$ " + datos.Rows[i].Cells["Adeudo"].Value.ToString() + "</td>";

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
            guardar.FileName = "RepoAdeudosEstado" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".pdf";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    int noPag = 1;
                    string codigoReporte;
                    for (int i = 0; i < datos.Rows.Count; i = i + 15)
                    {
                        pdfDoc.NewPage();
                        pdfDoc.Add(new Phrase(""));
                        codigoReporte = GenerarCodigoHTML(noPag, i);

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
