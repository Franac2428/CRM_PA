using System.ComponentModel.DataAnnotations;

namespace CRM_API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Nombre de usuario es requerido")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Nombre de usuario es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contraseña es requerida")]
        public string Password { get; set; }
    }
}
