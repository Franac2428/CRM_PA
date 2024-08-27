using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginHelper LoginHelper;
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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OnRegister(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = LoginHelper.OnRegister(model); 

                if (result.Status == "Success")
                {
                    TempData["RegistroExitoso"] = "Usuario registrado correctamente. Inicia sesión.";
                    return Redirect("/Account/Login");
                }
                else
                {
                    TempData["RegistroError"] = result.Mensaje;
                    return View("Register");
                }
            }
            else
            {
                TempData["RegistroError"] = "El modelo no es válido o faltan datos";
                return View("Register");
            }
        }

        [HttpPost]
        public ActionResult OnLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = LoginHelper.OnLogin(model);

                if (result.Status == "Success")
                {
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
