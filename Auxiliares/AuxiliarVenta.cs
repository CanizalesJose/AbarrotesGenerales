using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbarrotesGenerales
{
    internal class AuxiliarVenta
    {
        public AuxiliarVenta(String idArt, String idProv, int cant) {
            this.idArticulo = idArt;
            this.idProveedor = idProv;
            this.cantidad = cant;
        
        }
        public String idArticulo;
        public String idProveedor;
        public int cantidad;
    }
}
