using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FiltrosReportes
    {
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string? IdUsuarioCreacion { get; set; }
        public DateTime? MesPago { get; set; }
        public string? NombreCliente { get; set; }
    }
}
