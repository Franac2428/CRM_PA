using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.APIModels
{
    public class VerPagoModel
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
        public byte[]? ImagenComprobante { get; set; }
        public string? NumeroComprobannte { get; set; }
        public string? TipoImagen { get; set; }
        public bool? EnviadoAFacturar { get; set; }
        public decimal? PagaCon { get; set; }
        public string? Comentario { get; set; }
    }
}
