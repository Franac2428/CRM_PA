using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _HttpCA;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpCA)
        {
            _logger = logger;
            _HttpCA = httpCA;
        }

        public IActionResult Index()
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if(usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }
            else
            {
                ViewBag.UsuarioEnSesion = usuarioEnSesion;
                return View();
            }

        }

        
    }
}
