using CRM_API.Models;
using CRM_API.Services.Implementations;
using CRM_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        private ITokenService tokenService;

        public AuthController(UserManager<IdentityUser> userManager,ITokenService tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<CRMResponse> Login([FromBody] LoginRequestModel model)
        {
            IdentityUser user = await userManager.FindByNameAsync(model.Username);
            LoginModel usuario = new LoginModel();

            if (user != null)
            {
                var isCorrectPassword = await userManager.CheckPasswordAsync(user, model.Password);

                if (isCorrectPassword)
                {
                    var userRoles = await userManager.GetRolesAsync(user);

                    var jwtToken = tokenService.CreateToken(user, userRoles.ToList());

                    usuario.Token = jwtToken;
                    usuario.Roles = userRoles.ToList();
                    usuario.Username = user.UserName;
                    usuario.Id = user.Id.ToString();
                    usuario.Email = user.Email;

                    return new CRMResponse()
                    {
                        Codigo = 200,
                        Data = usuario,
                        Status = "Success",
                        Mensaje = "Ingreso correcto"
                    };
                }
                else
                {
                    return new CRMResponse()
                    {
                        Codigo = 400,
                        Status = "Failed",
                        Mensaje = "La contraseña indicada es incorrecta"
                    };
                }
            }
            else if(user == null)
            {
                return new CRMResponse()
                {
                    Codigo = 400,
                    Status = "Failed",
                    Mensaje = "No existe el usuario indicado"
                };
            }
            else
            {
                return new CRMResponse()
                {
                    Codigo = 400,
                    Status = "Failed",
                    Mensaje = "Unauthorized"
                };
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);

            if(userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new CRMResponse { Status="Error",Mensaje ="El usuario ya existe registrado"});
            }

            IdentityUser user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user,model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new CRMResponse { Status = "Error", Mensaje = "Error interno de servidor" });
            }

            return Ok(new CRMResponse {Status="Success",Mensaje="Usuario registrado satisfactoriamente" });
        }

    }
}
