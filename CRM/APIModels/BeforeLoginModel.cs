using System.ComponentModel.DataAnnotations;

namespace CRM.APIModels
{
    public class BeforeLoginModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string? Password { get; set; }
        public TokenModel? Token { get; set; }
        public List<string>? Roles { get; set; }

    }
}
