using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _HttpCA;
        IGraficosHelper _GraficosHelper;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpCA, IGraficosHelper graficosHelper)
        {
            _logger = logger;
            _HttpCA = httpCA;
            _GraficosHelper = graficosHelper;
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

        [HttpGet]
        public IActionResult GetGraficos()
        {
            try
            {
                var dataGraficos = _GraficosHelper.GetGraficos();
                return Ok(new { Status = "success", Data = dataGraficos });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "failed", Message = ex.Message });
            }
        }


    }
}
