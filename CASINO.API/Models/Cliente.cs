using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CASINO.API.Models
{
    public class Cliente
    {
        public int rut { get; set; }
        public string dv { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public DateTime fecha_creacion { get; set; }
    }
}