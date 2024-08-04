 using System.ComponentModel.DataAnnotations;

namespace CRM.ViewModels
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        public string Nombre { get; set; }
        [Required]
        public string? Correo { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        public string? Celular { get; set; }

        public int? IdTipoIdentificacion { get; set; }
        [Required]
        public string? Identificacion { get; set; }

        public bool? Eliminado { get; set; }

        public int? IdServicio { get; set; }

        public int? IdTipoPlan { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? IdUsuarioCreacion { get; set; }
        public string? IdUsuarioModificacion { get; set; }
    }
}
