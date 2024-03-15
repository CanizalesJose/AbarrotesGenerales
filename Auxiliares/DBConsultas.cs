using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbarrotesGenerales.Auxiliares
{
    internal class DBConsultas
    {
        public static string ConexionBD()
        {
            return @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\jose-\Desktop\AbarrotesGenerales\PuntoVenta.accdb";
        }
        //Consultas para la tabla Cliente
        public static string Cliente_ActualizarEstado(bool nuevoEstado, string idCliente)
        {
            return "UPDATE Cliente SET estadoCliente = "+ nuevoEstado +" WHERE (idCliente = '"+ idCliente +"')";
        }
        public static string Cliente_ConsultaCliente(string idCliente)
        {
            return "SELECT idCliente, nombreCliente, apellidoCliente, telefonoCliente, direccionCliente, estadoCliente FROM Cliente WHERE idCliente = '" + idCliente+"'";
        }
        public static string Cliente_DeleteCliente(string idCliente)
        {
            return "DELETE FROM Cliente WHERE idCliente = '"+ idCliente+"'";
        }
        public static string Cliente_InsertCliente(string idCliente, string nombreCliente, string apellidoCliente, string telefonoCliente, string direccionCliente, bool estadoCliente)
        {
            return "INSERT INTO Cliente (idCliente, nombreCliente, apellidoCliente, telefonoCliente, direccionCliente, estadoCliente) VALUES ('"+idCliente+"', '"+nombreCliente+"', '"+apellidoCliente+"', '"+telefonoCliente+"', '"+direccionCliente+"', "+estadoCliente+")";
        }
        public static string Cliente_UpdateCliente(string nombreCliente, string apellidoCliente, string telefonoCliente, string direccionCliente, bool estadoCliente, string idCliente)
        {
            return "UPDATE Cliente SET nombreCliente = '"+nombreCliente+"', apellidoCliente = '"+apellidoCliente+"', telefonoCliente = '"+telefonoCliente+"', direccionCliente = '"+direccionCliente+"', estadoCliente = "+estadoCliente+" WHERE idCliente = '"+idCliente+"'";
        }
        //Consultas para la tabla Adeudo
        public static string Adeudo_ConsultaAdeudo(string idAdeudo)
        {
            return "SELECT idAdeudo, fechaAdeudo, idCliente, estadoAdeudo, cantidadAdeudo FROM Adeudo WHERE idAdeudo = '"+idAdeudo+"'";
        }
        public static string Adeudo_ConsultaTotalAdeudo(bool estadoAdeudo)
        {
            return "SELECT SUM(cantidadAdeudo) as total FROM Adeudo WHERE estadoAdeudo = "+estadoAdeudo+"";
        }
        public static string Adeudo_DeleteQuery(string idAdeudo)
        {
            return "DELETE FROM Adeudo WHERE idAdeudo = '"+idAdeudo+"'";
        }
        public static string Adeudo_ReporEstado(bool estadoAdeudo)
        {
            return "SELECT Adeudo.idAdeudo, Adeudo.fechaAdeudo, Cliente.idCliente, Cliente.nombreCliente, Cliente.apellidoCliente, Cliente.telefonoCliente, Adeudo.cantidadAdeudo FROM (Adeudo INNER JOIN Cliente ON Adeudo.idCliente = Cliente.idCliente) WHERE (Adeudo.estadoAdeudo = "+estadoAdeudo+")";
        }
        public static string Adeudo_InsertQuery(string idAdeudo, DateTime fechaAdeudo, string idCliente, bool estadoAdeudo, double cantidadAdeudo)
        {
            return "INSERT INTO Adeudo (idAdeudo, fechaAdeudo, idCliente, estadoAdeudo, cantidadAdeudo) VALUES ('"+idAdeudo+"', '"+fechaAdeudo+"', '"+idCliente+"', "+estadoAdeudo+", '"+cantidadAdeudo+"')";
        }
        public static string Adeudo_TieneAdeudos(string idCliente)
        {
            return "SELECT Adeudo.idAdeudo, Cliente.idCliente, Adeudo.estadoAdeudo FROM (Adeudo INNER JOIN Cliente ON Adeudo.idCliente = Cliente.idCliente) WHERE (Cliente.idCliente = '"+idCliente+"') AND (Adeudo.estadoAdeudo = False)";
        }
        public static string Adeudo_UpdateQuery(DateTime fechaAdeudo, string idCliente, bool estadoAdeudo, double cantidadAdeudo, string idAdeudo)
        {
            return "UPDATE Adeudo SET fechaAdeudo = '"+fechaAdeudo+"', idCliente = '"+idCliente+"', estadoAdeudo = "+estadoAdeudo+", cantidadAdeudo = '"+cantidadAdeudo+"' WHERE (idAdeudo = '"+idAdeudo+"')";
        }
        //Consultas de la tabla Categoria
        public static string Categoria_GetData()
        {
            return "SELECT idCategoria, nombreCategoria, descripcionCategoria FROM Categoria ORDER BY idCategoria";
        }
        public static string Categoria_categoriaConsultaBase(string idCategoria)
        {
            return "SELECT descripcionCategoria, idCategoria, nombreCategoria FROM Categoria WHERE (idCategoria = '"+idCategoria+"')";
        }
        public static string Categoria_DeleteCategoria(string idCategoria)
        {
            return "DELETE FROM Categoria WHERE idCategoria = '"+idCategoria+"'";
        }
        public static string Categoria_InsertCategoria(string idCategoria, string nombreCategoria, string descripcionCategoria)
        {
            return "INSERT INTO Categoria (idCategoria, nombreCategoria, descripcionCategoria) VALUES ('"+idCategoria+"', '"+nombreCategoria+"', '"+descripcionCategoria+"')";
        }
        public static string Categoria_UpdateCategoria(string nombreCategoria, string descripcionCategoria, string idCategoria)
        {
            return "UPDATE Categoria SET nombreCategoria = '"+nombreCategoria+"', descripcionCategoria = '"+descripcionCategoria+"' WHERE (idCategoria = '"+idCategoria+"')";
        }
        //Consultas de la tabla Articulo
        public static string Articulo_GetData()
        {
            return "SELECT idArticulo, idCategoria, nombreArticulo, medidaArticulo FROM Articulo";
        }
        public static string Articulo_ConsultaDatosArticulo(string idArticulo)
        {
            return "SELECT Articulo.idArticulo, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.medidaArticulo, Categoria.nombreCategoria FROM (Articulo INNER JOIN Categoria ON Articulo.idCategoria = Categoria.idCategoria) WHERE (Articulo.idArticulo = '"+idArticulo+"')";
        }
        public static string Articulo_ConsultaProveedoresArticulo(string idArticulo)
        {
            return "SELECT Articulo.idArticulo, ArticuloProveedor.idProveedor FROM (Articulo LEFT OUTER JOIN ArticuloProveedor ON Articulo.idArticulo = ArticuloProveedor.idArticulo) WHERE (Articulo.idArticulo = '"+idArticulo+"')";
        }
        public static string Articulo_DeleteArticulo(string idArticulo)
        {
            return "DELETE FROM Articulo WHERE (idArticulo = '"+idArticulo+"')";
        }
        public static string Articulo_InsertarArticulo(string idArticulo, string idCategoria, string nombreArticulo, string medidaArticulo)
        {
            return "INSERT INTO Articulo (idArticulo, idCategoria, nombreArticulo, medidaArticulo) VALUES ('"+idArticulo+"', '"+idCategoria+"', '"+nombreArticulo+"', '"+medidaArticulo+"')";
        }
        public static string Articulo_selectArticulo(string idArticulo)
        {
            return "SELECT idArticulo, idCategoria, nombreArticulo, medidaArticulo FROM Articulo WHERE(idArticulo = '"+idArticulo+"')";
        }
        public static string Articulo_selecArticuloCategoria(string idArticulo)
        {
            return "SELECT Articulo.idArticulo, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.medidaArticulo, Categoria.idCategoria AS Expr1, Categoria.nombreCategoria, Categoria.descripcionCategoria FROM (Articulo INNER JOIN Categoria ON Articulo.idCategoria = Categoria.idCategoria) WHERE (Articulo.idArticulo = '"+idArticulo+"')";
        }
        public static string Articulo_UpdateArticulo(string idArticulo, string idCategoria, string nombreArticulo, string medidaArticulo)
        {
            return "UPDATE Articulo SET idArticulo = '"+idArticulo+"', idCategoria = '"+idCategoria+"', nombreArticulo = '"+nombreArticulo+"', medidaArticulo = '"+medidaArticulo+"' WHERE (idArticulo = '"+idArticulo+"')";
        }
        //Consultas de la tabla Proveedor
        public static string Proveedor_consultaProveedor(string idProveedor)
        {
            return "SELECT idProveedor, nombreProveedor, direccionProveedor, correoProveedor, telefonoProveedor FROM Proveedor WHERE (idProveedor = '"+idProveedor+"')";
        }
        public static string Proveedor_ConsultaProveedoresArticulo(string idArticulo)
        {
            return "SELECT Proveedor.idProveedor, Proveedor.nombreProveedor, Proveedor.direccionProveedor, Proveedor.correoProveedor, Proveedor.telefonoProveedor, ArticuloProveedor.idArticulo, ArticuloProveedor.idProveedor AS Expr1, ArticuloProveedor.precioArticulo, Articulo.idArticulo AS Expr2, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.medidaArticulo FROM ((Proveedor INNER JOIN ArticuloProveedor ON Proveedor.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) WHERE (ArticuloProveedor.idArticulo = '"+idArticulo+"')";
        }
        public static string Proveedor_DeleteProveedor(string idProveedor)
        {
            return "DELETE FROM Proveedor WHERE (idProveedor = '"+idProveedor+"')";
        }
        public static string Proveedor_InsertProveedor(string idProveedor, string nombreProveedor, string direccionProveedor, string correoProveedor, string telefonoProveedor)
        {
            return "INSERT INTO Proveedor (idProveedor, nombreProveedor, direccionProveedor, correoProveedor, telefonoProveedor) VALUES ('"+idProveedor+"', '"+nombreProveedor+"', '"+direccionProveedor+"', '"+correoProveedor+"', '"+telefonoProveedor+"')";
        }
        public static string Proveedor_UpdateProveedor(string nombreProveedor, string direccionProveedor, string correoProveedor, string telefonoProveedor, string idProveedor)
        {
            return "UPDATE Proveedor SET nombreProveedor = '"+nombreProveedor+"', direccionProveedor = '"+direccionProveedor+"', correoProveedor = '"+correoProveedor+"', telefonoProveedor = '"+telefonoProveedor+"' WHERE (idProveedor = '"+idProveedor+"')";
        }
        //Consultas de la tabla ArticuloProveedor
        public static string ArticuloProveedor_DeleteQuery(string idArticulo, string idProveedor)
        {
            return "DELETE FROM ArticuloProveedor WHERE (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string ArticuloProveedor_InsertQuery(string idArticulo, string idProveedor, double precioArticulo)
        {
            return "INSERT INTO ArticuloProveedor (idArticulo, idProveedor, precioArticulo) VALUES ('"+idArticulo+"', '"+idProveedor+"', '"+precioArticulo+"')";
        }
        public static string ArticuloProveedor_UpdateQuery(string idArticulo, string idProveedor, double precioArticulo)
        {
            return "UPDATE ArticuloProveedor SET idArticulo = '"+idArticulo+"', idProveedor = '"+idProveedor+"', precioArticulo = '"+precioArticulo+"' WHERE (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string ArticuloProveedor_validarArticuloProveedor(string idArticulo, string idProveedor)
        {
            return "SELECT idArticulo, idProveedor, precioArticulo FROM ArticuloProveedor WHERE (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        //Consultas de la tabla Entrada
        public static string Entrada_GetData()
        {
            return "SELECT idEntrada, fechaEntrada FROM Entrada";
        }
        public static string Entrada_ConsultaArticulosEntrada(string idEntrada)
        {
            return "SELECT DetalleEntrada.idArticulo, DetalleEntrada.idProveedor, DetalleEntrada.costoArticulo, DetalleEntrada.cantidadArticulo, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.medidaArticulo, Categoria.nombreCategoria, Proveedor.nombreProveedor, Entrada.idEntrada FROM (((((Entrada INNER JOIN DetalleEntrada ON Entrada.idEntrada = DetalleEntrada.idEntrada) INNER JOIN ArticuloProveedor ON DetalleEntrada.idArticulo = ArticuloProveedor.idArticulo AND DetalleEntrada.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) INNER JOIN Categoria ON Articulo.idCategoria = Categoria.idCategoria) INNER JOIN Proveedor ON ArticuloProveedor.idProveedor = Proveedor.idProveedor) WHERE (Entrada.idEntrada = '"+idEntrada+"')";
        }
        public static string Entrada_consultaEntrada(string idEntrada)
        {
            return "SELECT idEntrada, fechaEntrada FROM Entrada WHERE (idEntrada = '"+idEntrada+"')";
        }
        public static string Entrada_DeleteEntrada(string idEntrada)
        {
            return "DELETE FROM Entrada WHERE (idEntrada = '"+idEntrada+"')";
        }
        public static string Entrada_ReporteEntradaPeriodo(DateTime fechaInicio, DateTime fechaFinal)
        {
            return "SELECT E.idEntrada, E.fechaEntrada, SUM(DE.cantidadArticulo) AS noArticulos, consulta.Subtotal FROM ((Entrada E INNER JOIN DetalleEntrada DE ON E.idEntrada = DE.idEntrada) INNER JOIN (SELECT idEntrada, SUM(cantidadArticulo * costoArticulo) AS Subtotal FROM DetalleEntrada GROUP BY  idEntrada) consulta ON E.idEntrada = consulta.idEntrada) WHERE (E.fechaEntrada BETWEEN "+fechaInicio.ToString("d")+" AND "+fechaFinal.ToString("d")+" GROUP BY E.idEntrada, E.fechaEntrada, consulta.Subtotal";
        }
        public static string Entrada_InsertarEntrada(string idEntrada, DateTime fechaEntrada)
        {
            return "INSERT INTO Entrada (idEntrada, fechaEntrada) VALUES ('"+idEntrada+"', '"+fechaEntrada+"')";
        }
        public static string Entrada_UpdateEntrada(DateTime fechaEntrada, string idEntrada)
        {
            return "UPDATE Entrada SET fechaEntrada = '"+fechaEntrada+"' WHERE (idEntrada = '"+idEntrada+"')";
        }
        //Consultas de la tabla DetalleEntrada
        public static string DetalleEntrada_ConsultaArticulosEntrada(string idEntrada)
        {
            return "SELECT DetalleEntrada.idEntrada, DetalleEntrada.idArticulo, DetalleEntrada.costoArticulo, DetalleEntrada.cantidadArticulo, DetalleEntrada.idProveedor, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.idArticulo AS Expr1, Articulo.medidaArticulo, Categoria.idCategoria AS Expr2, Categoria.nombreCategoria, Categoria.descripcionCategoria, Proveedor.idProveedor AS Expr3, Proveedor.nombreProveedor, Proveedor.correoProveedor, Proveedor.direccionProveedor FROM (((DetalleEntrada INNER JOIN Articulo ON DetalleEntrada.idArticulo = Articulo.idArticulo) INNER JOIN Categoria ON Articulo.idCategoria = Categoria.idCategoria) INNER JOIN Proveedor ON DetalleEntrada.idProveedor = Proveedor.idProveedor) WHERE (DetalleEntrada.idEntrada = '"+idEntrada+"')";
        }
        public static string DetalleEntrada_consultaEntrada(string idEntrada, string idArticulo, string idProveedor)
        {
            return "SELECT idEntrada, idArticulo, idProveedor, costoArticulo, cantidadArticulo FROM DetalleEntrada WHERE (idEntrada = '"+idEntrada+"') AND (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string DetalleEntrada_consultaEntradaTotal(string idEntrada)
        {
            return "SELECT DetalleEntrada.idEntrada, DetalleEntrada.idArticulo, DetalleEntrada.idProveedor, DetalleEntrada.costoArticulo, DetalleEntrada.cantidadArticulo, Articulo.nombreArticulo FROM ((DetalleEntrada INNER JOIN ArticuloProveedor ON DetalleEntrada.idArticulo = ArticuloProveedor.idArticulo AND DetalleEntrada.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) WHERE (DetalleEntrada.idEntrada = '"+idEntrada+"')";
        }
        public static string DetalleEntrada_DeleteQuery(string idEntrada, string idArticulo, string idProveedor)
        {
            return "DELETE FROM DetalleEntrada WHERE (idEntrada = '"+idEntrada+"') AND (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string DetalleEntrada_InsertQuery(string idEntrada, string idArticulo, string idProveedor, double costoArticulo, int cantidadArticulo)
        {
            return "INSERT INTO DetalleEntrada (idEntrada, idArticulo, idProveedor, costoArticulo, cantidadArticulo) VALUES ('"+idEntrada+"', '"+idArticulo+"', '"+idProveedor+"', '"+costoArticulo+"', '"+cantidadArticulo+"')";
        }
        public static string DetalleEntrada_UpdateQuery(double costoArticulo, int cantidadArticulo, string idEntrada, string idArticulo, string idProveedor)
        {
            return "UPDATE DetalleEntrada SET costoArticulo = '"+costoArticulo+"', cantidadArticulo = '"+cantidadArticulo+"' WHERE (idEntrada = '"+idEntrada+"') AND (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        //Consultas de la tabla Venta
        public static string Venta_GetData()
        {
            return "SELECT idVenta, fechaVenta FROM Venta";
        }
        public static string Venta_DeleteVenta(string idVenta)
        {
            return "DELETE FROM Venta WHERE (idVenta = '"+idVenta+"')";
        }
        public static string Venta_ReporteVentasPeriodo(DateTime fechaInicio, DateTime fechaFinal)
        {
            return "SELECT Venta.idVenta, Venta.fechaVenta, SUM(DetalleVenta.cantidadVenta) AS noArticulos, consulta.total FROM ((Venta INNER JOIN DetalleVenta ON Venta.idVenta = DetalleVenta.idVenta) INNER JOIN (SELECT DetalleVenta_1.idVenta, SUM(ArticuloProveedor.precioArticulo * DetalleVenta_1.cantidadVenta) AS total FROM (DetalleVenta DetalleVenta_1 INNER JOIN ArticuloProveedor ON DetalleVenta_1.idArticulo = ArticuloProveedor.idArticulo AND DetalleVenta_1.idProveedor = ArticuloProveedor.idProveedor) GROUP BY  DetalleVenta_1.idVenta) consulta ON Venta.idVenta = consulta.idVenta) WHERE (Venta.fechaVenta BETWEEN \""+fechaInicio +"\" AND \""+fechaFinal+"\") GROUP BY Venta.idVenta, Venta.fechaVenta, consulta.total";
        }
        public static string Venta_InsertVenta(string idVenta, DateTime fechaVenta)
        {
            return "INSERT INTO Venta (idVenta, fechaVenta) VALUES ('"+idVenta+"', '"+fechaVenta+"')";
        }
        public static string Venta_selectVentaBase(string idVenta)
        {
            return "SELECT idVenta, fechaVenta FROM Venta WHERE (idVenta = '"+idVenta+"')";
        }
        public static string Venta_UpdateVenta(DateTime fechaVenta, string idVenta)
        {
            return "UPDATE Venta SET fechaVenta = '"+fechaVenta+"' WHERE (idVenta = '"+idVenta+"')";
        }
        //Consultas de la tabla DetalleVenta
        public static string DetalleVenta_ActualizarDetalleVenta(int cantidadVenta, string idVenta, string idArticulo, string idProveedor)
        {
            return "UPDATE DetalleVenta SET cantidadVenta = '"+cantidadVenta+"' WHERE (idVenta = '"+idVenta+"') AND (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string DetalleVenta_actualizarTablaDetalleVenta(string idVenta)
        {
            return "SELECT DetalleVenta.idVenta, DetalleVenta.idArticulo, DetalleVenta.idProveedor, DetalleVenta.cantidadVenta, ArticuloProveedor.idArticulo AS Expr1, ArticuloProveedor.idProveedor AS Expr2, ArticuloProveedor.precioArticulo, Articulo.idArticulo AS Expr3, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.medidaArticulo, Proveedor.idProveedor AS Expr4, Proveedor.nombreProveedor, Proveedor.direccionProveedor, Proveedor.correoProveedor, Proveedor.telefonoProveedor FROM (((DetalleVenta INNER JOIN ArticuloProveedor ON DetalleVenta.idArticulo = ArticuloProveedor.idArticulo AND DetalleVenta.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) INNER JOIN Proveedor ON ArticuloProveedor.idProveedor = Proveedor.idProveedor) WHERE (DetalleVenta.idVenta = '"+idVenta+"')";
        }
        public static string DetalleVenta_ConsultarArticulosVenta(string idVenta)
        {
            return "SELECT DetalleVenta.idVenta, DetalleVenta.idArticulo, DetalleVenta.idProveedor, DetalleVenta.cantidadVenta, ArticuloProveedor.precioArticulo, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.medidaArticulo, Categoria.nombreCategoria, Proveedor.nombreProveedor FROM ((((DetalleVenta INNER JOIN ArticuloProveedor ON DetalleVenta.idArticulo = ArticuloProveedor.idArticulo AND DetalleVenta.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) INNER JOIN Proveedor ON ArticuloProveedor.idProveedor = Proveedor.idProveedor) INNER JOIN Categoria ON Articulo.idCategoria = Categoria.idCategoria) WHERE (DetalleVenta.idVenta = '"+idVenta+"')";
        }
        public static string DetalleVenta_ConsultarArticulosVentaProveedor(string idVenta, string idArticulo, string idProveedor)
        {
            return "SELECT idVenta, idArticulo, idProveedor, cantidadVenta FROM DetalleVenta WHERE (idVenta = '"+idVenta+"') AND (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string DetalleVenta_DeleteQuery(string idVenta, string idArticulo, string idProveedor)
        {
            return "DELETE FROM DetalleVenta WHERE idVenta='"+idVenta+"' AND idArticulo='"+idArticulo+"' AND idProveedor='"+idProveedor+"'";
        }
        public static string DetalleVenta_InsertQuery(string idVenta, string idArticulo, string idProveedor, int cantidadVenta)
        {
            return "INSERT INTO DetalleVenta (idVenta, idArticulo, idProveedor, cantidadVenta) VALUES ('"+idVenta+"', '"+idArticulo+"', '"+idProveedor+"', '"+cantidadVenta+"')";
        }
        public static string DetalleVenta_selectDetalleVenta(string idVenta)
        {
            return "SELECT idVenta, idArticulo, cantidadVenta FROM DetalleVenta WHERE (idVenta = '"+idVenta+"')";
        }
        //Consultas de la tabla Inventario
        public static string Inventario_consultaInventarioGeneral()
        {
            return "SELECT Inventario.idArticulo, Inventario.idProveedor, Inventario.cantidadInventario, ArticuloProveedor.idArticulo AS Expr1, ArticuloProveedor.idProveedor AS Expr2, ArticuloProveedor.precioArticulo, Articulo.idArticulo AS Expr3, Articulo.idCategoria, Articulo.nombreArticulo, Articulo.medidaArticulo, Proveedor.idProveedor AS Expr4, Proveedor.nombreProveedor, Proveedor.direccionProveedor, Proveedor.correoProveedor, Proveedor.telefonoProveedor FROM (((Inventario INNER JOIN ArticuloProveedor ON Inventario.idArticulo = ArticuloProveedor.idArticulo AND Inventario.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) INNER JOIN Proveedor ON ArticuloProveedor.idProveedor = Proveedor.idProveedor)";
        }
        public static string Inventario_consultaInventarioTotal(string idArticulo, string idProveedor)
        {
            return "SELECT Inventario.idArticulo, Inventario.cantidadInventario, ArticuloProveedor.precioArticulo, Articulo.nombreArticulo, Proveedor.nombreProveedor FROM (((Inventario INNER JOIN ArticuloProveedor ON Inventario.idArticulo = ArticuloProveedor.idArticulo AND Inventario.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) INNER JOIN Proveedor ON ArticuloProveedor.idProveedor = Proveedor.idProveedor) WHERE (Inventario.idArticulo = '"+idArticulo+"') AND (Inventario.idProveedor = '"+idProveedor+"')";
        }
        public static string Inventario_DeleteQuery(string idArticulo, string idProveedor)
        {
            return "DELETE FROM Inventario WHERE (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string Inventario_ReporteInventarioCategoria(string idCategoria)
        {
            return "SELECT Inventario.idArticulo, Inventario.idProveedor, Inventario.cantidadInventario, ArticuloProveedor.precioArticulo, Proveedor.nombreProveedor, Articulo.idCategoria, Articulo.nombreArticulo, Categoria.nombreCategoria FROM ((((Inventario INNER JOIN ArticuloProveedor ON Inventario.idArticulo = ArticuloProveedor.idArticulo AND Inventario.idProveedor = ArticuloProveedor.idProveedor) INNER JOIN Proveedor ON ArticuloProveedor.idProveedor = Proveedor.idProveedor) INNER JOIN Articulo ON ArticuloProveedor.idArticulo = Articulo.idArticulo) INNER JOIN Categoria ON Articulo.idCategoria = Categoria.idCategoria) WHERE (Articulo.idCategoria = '"+idCategoria+"')";
        }
        public static string Inventario_InsertQuery(string idArticulo, string idProveedor, int cantidadInventario)
        {
            return "INSERT INTO Inventario (idArticulo, idProveedor, cantidadInventario) VALUES ('"+idArticulo+"', '"+idProveedor+"', '"+cantidadInventario+"')";
        }
        public static string Inventario_UpdateQuery(int cantidadInventario, string idArticulo, string idProveedor)
        {
            return "UPDATE Inventario SET cantidadInventario = '"+cantidadInventario+"' WHERE (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        public static string Inventario_ValidarArticuloProveedorInventario(string idArticulo, string idProveedor)
        {
            return "SELECT idArticulo, idProveedor, cantidadInventario FROM Inventario WHERE (idArticulo = '"+idArticulo+"') AND (idProveedor = '"+idProveedor+"')";
        }
        //Realizar cambios a la base de datos
        public static void EjecutarComando(string query)
        {
            OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
            OleDbCommand comando = new OleDbCommand(query, conexion);
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            else
            {
                comando.ExecuteNonQuery();
                conexion.Close();
                
            }
            
        }
        //Llenar un DataTable con una consulta
        public static DataTable EjecutarConsulta(string query)
        {
            OleDbConnection conexion = new OleDbConnection(DBConsultas.ConexionBD());
            OleDbCommand comando = new OleDbCommand(query, conexion);
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
                DataTable consulta = new DataTable();
                consulta.Clear();
                OleDbDataReader reader = comando.ExecuteReader();
                consulta.Load(reader);
                conexion.Close();
                return consulta;
            }
            else
            {
                DataTable consulta = new DataTable();
                consulta.Clear();
                OleDbDataReader reader = comando.ExecuteReader();
                consulta.Load(reader);
                conexion.Close();
                return consulta;
            }
            
        }
        //Fin de la clase
    }
}
