using CRM.APIModels;
using CRM.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class InfoEmpresaController : Controller
    {
        IInfoEmpresaHelper InfoEmpresaHelper;
        private readonly IHttpContextAccessor _HttpCA;

        public InfoEmpresaController(IInfoEmpresaHelper infoEmpresaHelper, IHttpContextAccessor httpCA)
        {
            InfoEmpresaHelper = infoEmpresaHelper;
            _HttpCA = httpCA;
        }

        public IActionResult Agregar()
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }
            else
            {
                var result = InfoEmpresaHelper.Get(1);

                ViewBag.UsuarioEnSesion = usuarioEnSesion;
                return View(result.Data);
            }
        }

        public IActionResult Editar()
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
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
