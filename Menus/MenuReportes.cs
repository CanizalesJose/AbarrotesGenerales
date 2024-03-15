using AbarrotesGenerales.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Reportes
{
    public partial class MenuReportes : Form
    {
        public MenuReportes()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteAdeudosEstado reporteAdeudos = new ReporteAdeudosEstado();
            reporteAdeudos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReporteInventarioCategoria reporteInventario = new ReporteInventarioCategoria();
            reporteInventario.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReporteVentasPeriodo reporte = new ReporteVentasPeriodo();
            reporte.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReporteEntradasPeriodo reporte = new ReporteEntradasPeriodo();
            reporte.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConsultaArticulosVenta consulta = new ConsultaArticulosVenta();
            consulta.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConsultaArticulosEntrada consulta = new ConsultaArticulosEntrada();
            consulta.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ConsultaProveedoresArticulo consulta = new ConsultaProveedoresArticulo();
            consulta.Show();
        }
    }
}
