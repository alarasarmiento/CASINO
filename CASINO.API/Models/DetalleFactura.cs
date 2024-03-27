using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASINO.API.Models
{
    public class DetalleFactura
    {
        public int codigo_detalle { get; set; }
        public int numero_factura { get; set; }
        public int codigo_producto { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public int subtotal { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}