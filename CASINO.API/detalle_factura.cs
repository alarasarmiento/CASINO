//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CASINO.API
{
    using System;
    using System.Collections.Generic;
    
    public partial class detalle_factura
    {
        public int codigo_detalle { get; set; }
        public Nullable<int> numero_factura { get; set; }
        public Nullable<int> codigo_producto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<int> precio { get; set; }
        public Nullable<int> subtotal { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
    
        public virtual factura factura { get; set; }
        public virtual producto producto { get; set; }
    }
}
