using CRM_API.Models;
using Microsoft.AspNetCore.Identity;

namespace CRM_API.Services.Interfaces
{
    public interface ITokenService
    {
        TokenModel CreateToken(IdentityUser user, List<string> roles);
    }
}
