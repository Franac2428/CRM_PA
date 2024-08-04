using CRM.APIModels;
using CRM.Helpers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class AccountController : Controller
    {
        ILoginHelper LoginHelper;
        private readonly IHttpContextAccessor _HttpCA;

        public AccountController(ILoginHelper loginHelper, IHttpContextAccessor httpCA)
        {
            LoginHelper = loginHelper;
            _HttpCA = httpCA;
        }

        public ActionResult Login()
        {
            _HttpCA.HttpContext?.Session.Clear();
            return View();
        }

        public ActionResult Logout()
        {
            _HttpCA.HttpContext?.Session.Clear();
            TempData["Logout"] = "Cierre de sesión exitoso";
            return Redirect("/Account/Login");
        }

        //Methods

        [HttpPost]
        public ActionResult OnLogin(LoginModel model)
        {
            if (ModelState.IsValid) {
                var result = LoginHelper.OnLogin(model);

                if (result.Status == "Success") {
                    var userObj = JsonConvert.SerializeObject(result.Data);
                    _HttpCA.HttpContext?.Session.SetString("UsuarioEnSesion", userObj);
                    return Redirect("/Home/Index");

                }
                else
                {
                    TempData["LoginError"] = result.Mensaje;
                    return Redirect("/Account/Login");
                }

            }
            else
            {
                TempData["LoginError"] = "El modelo no es válido o faltan datos";
                return Redirect("/Account/Login");
            }
        }
        
    }
}
