using System.ComponentModel.DataAnnotations;

namespace CRM_API.Models
{
    public class LoginModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public TokenModel? Token { get; set; }
        public List<string>? Roles { get; set; }
    }
}
