using AbarrotesGenerales.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales
{
    public partial class MenuCatalogos : Form
    {
        public MenuCatalogos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaCategoria catalogoCategoria = new PantallaCategoria();
            catalogoCategoria.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PantallaProveedor proveedores = new PantallaProveedor();
            proveedores.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PantallaCliente pantallaCliente = new PantallaCliente();
            pantallaCliente.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PantallaEntrada pantallaEntrada = new PantallaEntrada();
            pantallaEntrada.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PantallaVenta pantallaVenta = new PantallaVenta();
            pantallaVenta.Show();
        }
    }
}
