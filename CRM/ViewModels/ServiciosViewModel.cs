using System.ComponentModel.DataAnnotations;

namespace CRM.ViewModels
{
    public class ServiciosViewModel
    {
        public int IdServicio { get; set; }

        [Required(ErrorMessage = "El nombre del Servicio es obligatorio.")]
        public string Nombre { get; set; }
        [Required]

		public string? Monto { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string? IdUsuarioCreacion { get; set; }

		public string? IdUsuarioModificacion { get; set; }

		public string? IdMoneda { get; set; }

		public string? Eliminado { get; set; }

	}
}
