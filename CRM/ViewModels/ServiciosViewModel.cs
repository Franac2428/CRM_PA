using System.ComponentModel.DataAnnotations;

namespace CRM.ViewModels
{
    public class ServiciosViewModel
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }

		public decimal? Monto { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string? IdUsuarioCreacion { get; set; }

		public string? IdUsuarioModificacion { get; set; }

		public int? IdMoneda { get; set; }

		public bool? Eliminado { get; set; }

	}
}
