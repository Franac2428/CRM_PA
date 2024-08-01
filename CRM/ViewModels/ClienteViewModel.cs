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
    }
}
