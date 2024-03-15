using AbarrotesGenerales.Catalogos;
using AbarrotesGenerales.Mantenimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Menus
{
    public partial class MenuMantenimientos : Form
    {
        public MenuMantenimientos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MantenimientoArticulo mantenimientoArticulo = new MantenimientoArticulo();
            mantenimientoArticulo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MantenimientoArticuloProveedor mantenimientoArticuloProveedor = new MantenimientoArticuloProveedor();
            mantenimientoArticuloProveedor.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MantenimientoDetalleEntrada mantenimientoDetalleEntrada = new MantenimientoDetalleEntrada();
            mantenimientoDetalleEntrada.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MantenimientoAdeudo adeudo = new MantenimientoAdeudo();
            adeudo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MantenimientoInventario inventario = new MantenimientoInventario();
            inventario.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MantenimientoDetalleVenta venta = new MantenimientoDetalleVenta();
            venta.Show();
        }
    }
}
