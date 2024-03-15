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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using AbarrotesGenerales.Auxiliares;
using System.Data.OleDb;

namespace AbarrotesGenerales.Reportes
{
    public partial class ReporteEntradasPeriodo : Form
    {
        public ReporteEntradasPeriodo()
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

        private void ReporteEntradasPeriodo_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToString();
            labelFechaReporte.Visible = false;
            label7.Visible = false;
            textBoxTotal.Visible = false;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            labelFechaReporte.Visible = false;
            label7.Visible = false;
            textBoxTotal.Visible = false;
            button3.Visible = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                labelFechaReporte.Visible = true;
                labelFechaReporte.Text = DateTime.Now.ToString();
                label7.Visible = true;
                textBoxTotal.Visible = true;
                DateTime fecha1 = DateTime.Parse(dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year + " 00:00:00");
                DateTime fecha2 = DateTime.Parse(dateTimePicker2.Value.Day + "/" + dateTimePicker2.Value.Month + "/" + dateTimePicker2.Value.Year + " 23:59:59");

                //DataTable consulta = this.entradaTableAdapter1.ReporteEntradaPeriodo(fecha1, fecha2);

                OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
                OleDbCommand comando = new OleDbCommand("SELECT       E.idEntrada, E.fechaEntrada, SUM(DE.cantidadArticulo) AS noArticulos, consulta.Subtotal\r\nFROM            ((Entrada E INNER JOIN\r\n                         DetalleEntrada DE ON E.idEntrada = DE.idEntrada) INNER JOIN\r\n                             (SELECT       idEntrada, SUM(cantidadArticulo * costoArticulo) AS Subtotal\r\n                               FROM             DetalleEntrada\r\n                               GROUP BY  idEntrada) consulta ON E.idEntrada = consulta.idEntrada)\r\nWHERE        (E.fechaEntrada BETWEEN ? AND ?)\r\nGROUP BY E.idEntrada, E.fechaEntrada, consulta.Subtotal", conexion);

                DataTable consulta = new DataTable();
                conexion.Open();
                comando.Parameters.AddWithValue("p1", fecha1);
                comando.Parameters.AddWithValue("p2", fecha2);
                OleDbDataReader reader = comando.ExecuteReader();
                consulta.Clear();
                consulta.Load(reader);
                conexion.Close();

                string idVenta, fechaVenta;
                int cantidad;
                double subtotal;
                double total = 0;
                for (int i = 0; i < consulta.Rows.Count; i++)
                {
                    idVenta = consulta.Rows[i]["idEntrada"].ToString();
                    fechaVenta = consulta.Rows[i]["fechaEntrada"].ToString();
                    cantidad = int.Parse(consulta.Rows[i]["noArticulos"].ToString());
                    subtotal = double.Parse(consulta.Rows[i]["Subtotal"].ToString());
                    total = total + subtotal;

                    dataGridView1.Rows.Add(idVenta, fechaVenta, cantidad, subtotal);
                }
                textBoxTotal.Text = total.ToString();
                button3.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GenerarCodigoReporte(int noPag, int posTabla)
        {
            string codigoReporte = Properties.Resources.reporteentradas.ToString();

            //Reemplazar las variables del archivo
            codigoReporte = codigoReporte.Replace("@fechareporte", labelFechaReporte.Text);
            codigoReporte = codigoReporte.Replace("@fechauno", dateTimePicker1.Value.ToString("dd/MMMM/yyyy").ToUpper());
            codigoReporte = codigoReporte.Replace("@fechados", dateTimePicker2.Value.ToString("dd/MMMM/yyyy").ToUpper());
            codigoReporte = codigoReporte.Replace("@total", "$ " + textBoxTotal.Text);
            //El numero de la pagina aumento en el método principal
            codigoReporte = codigoReporte.Replace("@pag", "Pag. " + noPag);

            //Llenar la tabla del html con los registros del DataGridView
            string filas = string.Empty;

            //Llena la tabla a partir de la posicion de la tabla en la que se quedo.
            //la primera vez inicia en la posicion 0 y por cada ejecución se aumenta en 20
            //Por lo que se crea una página cada 20 registros
            //Este aumento ocurre en el ciclo for del método principal
            for (int i = posTabla; i < dataGridView1.Rows.Count; i++)
            {
                filas += "<tr>";

                filas += "<td>" + dataGridView1.Rows[i].Cells["idEntrada"].Value.ToString() + "</td>";
                filas += "<td>" + dataGridView1.Rows[i].Cells["fechaEntrada"].Value.ToString() + "</td>";
                filas += "<td>" + dataGridView1.Rows[i].Cells["noArticulos"].Value.ToString() + "</td>";
                filas += "<td>" + "$ " + dataGridView1.Rows[i].Cells["Subtotal"].Value.ToString() + "</td>";

                filas += "</tr>";

                // posTabla + 19 es la forma de determinar si ya pasaron las 20 posiciones
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
            //Método Principal para generar el archivo PDF
            //Crea una ventana de selección de ubicación de archivo y le asigna un nombre predeterminado
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = "RepoEntradaPeriodo" + DateTime.Now.ToString("ddMMyyyHHmmss") + ".pdf";

            //Inicializa el numero de página en 1
            int noPag = 1;
            //Si se aceptó el guardar el archivo, entonces procede a crearlo
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                //Crea un documento, leyendo la ubicación donde queremos guardar el archivo
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    //Crea un documento PDF con un size y margenes
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    //Crea un escritor de archivos, escribira en el archivo creado y usara la ubicación leida
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    //Inicia a escribir en el documento
                    pdfDoc.Open();

                    //Inicia el ciclo que determinara el numero de paginas
                    //Se repetirá hasta que i (posicion inicial en renglones de la tabla) sea igual o mayor que
                    //el numero de renglones totales en la tabla y aumentara en 20 cada vez para poner solo
                    //20 registros en cada página
                    for (int i = 0; i < dataGridView1.Rows.Count; i = i + 15)
                    {
                        //Empieza parte del código que genera una pagina individual del PDF
                        //Crea una nueva página con un elemento
                        pdfDoc.NewPage();
                        pdfDoc.Add(new Phrase(""));

                        //Generar código html del reporte usando el numero de pagina y a partir de qué 
                        //renglon debe llenar el reporte
                        string codigoReporte = GenerarCodigoReporte(noPag, i);

                        //Traduce el texto a html
                        using (StringReader sr = new StringReader(codigoReporte))
                        {
                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                        }
                        //Termina parte del código que genera una pagina individual del PDF
                        //Aumenta el numero de pagina por si necesita crear otra
                        noPag++;
                    }
                    //Cierra el documento y lo genera
                    pdfDoc.Close();
                    stream.Close();
                }
                //Archivo generado con éxito
                MessageBox.Show("Archivo generado.");
                Process.Start(guardar.FileName);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenerarPDF();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            button3.Visible = false;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            button3.Visible = false;
        }
    }
}
