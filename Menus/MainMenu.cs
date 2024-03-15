using AbarrotesGenerales.Catalogos;
using AbarrotesGenerales.Menus;
using AbarrotesGenerales.Reportes;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            OcultarSubPaneles();
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OcultarSubMenu();
            var confirmResult = MessageBox.Show("Cerrar el programa", "Confirmar",  MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void OcultarSubPaneles()
        {
            panelSubAdministracion.Visible = false;
            panelSubInfo.Visible = false;
        }
        private void OcultarSubMenu()
        {
            if (panelSubAdministracion.Visible == true)
                panelSubAdministracion.Visible = false;
            if (panelSubInfo.Visible == true)
                panelSubInfo.Visible = false;
        }
        private void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubMenu();
                subMenu.Visible = true;
            }else
                subMenu.Visible = false;
        }
        #region AdministracionSubMenu
        private void buttonAdministracion_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelSubAdministracion);
        }

        private void buttonCatCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PantallaCategoria());
            OcultarSubMenu();
        }

        private void buttonCatProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PantallaProveedor());
            OcultarSubMenu();
        }

        private void buttonCatClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PantallaCliente());
            OcultarSubMenu();
        }

        private void buttonCatEntradas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PantallaEntrada());
            OcultarSubMenu();
        }

        private void buttonCatVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PantallaVenta());
            OcultarSubMenu();
        }

        private void buttonManInventario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Mantenimientos.MantenimientoInventario());
            OcultarSubMenu();
        }

        private void buttonManDVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Mantenimientos.MantenimientoDetalleVenta());
            OcultarSubMenu();
        }

        private void buttonManDEntradas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Mantenimientos.MantenimientoDetalleEntrada());
            OcultarSubMenu();
        }

        private void buttonManAdeudos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Mantenimientos.MantenimientoAdeudo());
            OcultarSubMenu();
        }

        private void buttonManArticulos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Mantenimientos.MantenimientoArticulo());
            OcultarSubMenu();
        }

        private void buttonManArtProv_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Mantenimientos.MantenimientoArticuloProveedor());
            OcultarSubMenu();
        }
        #endregion

        #region InformacionSubMenu
        private void buttonInformacion_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelSubInfo);
        }
        //Adeudo por Estado
        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ReporteAdeudosEstado());
            OcultarSubMenu();
        }
        //Venta por Periodo
        private void button19_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ReporteVentasPeriodo());
            OcultarSubMenu();
        }
        //Entrada por Periodo
        private void button20_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ReporteEntradasPeriodo());
            OcultarSubMenu();
        }
        //Inventario por Categorias
        private void button21_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ReporteInventarioCategoria());
            OcultarSubMenu();
        }
        //Articulos de Ventas
        private void button23_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Consultas.ConsultaArticulosVenta());
            OcultarSubMenu();
        }
        //Articulos de Entradas
        private void button24_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Consultas.ConsultaArticulosEntrada());
            OcultarSubMenu();
        }
        //Proveedores de un articulo
        private void button25_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Consultas.ConsultaProveedoresArticulo());
            OcultarSubMenu();
        }
        #endregion
        private void buttonVentaGeneral_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new VentaGeneral());
            OcultarSubMenu();
        }

        private void buttonAcercaDe_Click(object sender, EventArgs e)
        {
            OcultarSubMenu();
            MessageBox.Show("Alumno: Canizalez López José Manuel\nNo. Control: 20490690\n\nDocente: Avelar Martinez Fernando\n\nAsignatura: EZA6 Ingenieria de Software", "Información General");
        }

        private Form activo = null;
        private void AbrirFormulario(Form hijo)
        {
            if (activo != null)
                activo.Close();
            activo = hijo;
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            panelFormHijo.Controls.Add(hijo);
            panelFormHijo.Tag = hijo;
            hijo.BringToFront();
            hijo.Show();
        }
    }
}
