using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASINO.API.Models
{
    public class Factura
    {
        public int numero_factura { get; set; }
        public int cliente_asociado { get; set; }
        public int total_factura { get; set; }
        public DateTime fecha_factura { get; set; }
        public List<DetalleFactura> detalle { get; set; }
    }
}