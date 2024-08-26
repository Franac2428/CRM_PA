using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.ViewModels
{
    public class ListaPagosViewModel
    {
        public int IdPago { get; set; }
        public int? IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public decimal? MontoPago { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? MesPago { get; set; }
        public int IdEstadoPago { get; set; }
        public string EstadoPago { get; set; }
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public bool? Eliminado { get; set; }
        public int IdSaldo { get; set; }
        public decimal? MontoSaldo { get; set; }
        public int IdTipoPlan { get; set; }
        public int? IdMoneda { get; set; }
        public bool? EnviadoAFacturar { get; set; }



    }
}
