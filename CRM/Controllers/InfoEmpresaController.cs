using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class InfoEmpresaController : Controller
    {
        IInfoEmpresaHelper _infoEmpresaHelper;
        private readonly IHttpContextAccessor _HttpCA;

        public InfoEmpresaController(IInfoEmpresaHelper infoEmpresaHelper, IHttpContextAccessor httpContextAccessor)
        {
            _infoEmpresaHelper = infoEmpresaHelper;
            _HttpCA = httpContextAccessor;
        }

        public IActionResult Index()
        {
            try
            {
                var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

                if (usuarioEnSesion == null)
                {
                    TempData["LoginError"] = "Tiempo de sesión finalizó";
                    return Redirect("/Account/Login");
                }

                ViewBag.UsuarioEnSesion = usuarioEnSesion;
                var listadoEmpresas = _infoEmpresaHelper.GetEmpresas();

                if (!listadoEmpresas.Any())
                {
                    ViewData["NoDataList"] = "No existen datos para mostrar";
                    return View(new List<InfoEmpresaViewModel>());
                }

                return View(listadoEmpresas);
            }
            catch (Exception ex)
            {
                ViewData["ErrorList"] = $"Ocurrió un error al listar la información: {ex.Message}";
                return View(new List<InfoEmpresaViewModel>());
            }
        }

        public IActionResult Agregar()
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }

            ViewBag.UsuarioEnSesion = usuarioEnSesion;
            ViewData["TiposIdentificacion"] = GetTiposIdentificacion();
            return View();
        }

        public IActionResult Editar(int id)
        {
            try
            {
                var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

                if (usuarioEnSesion == null)
                {
                    TempData["LoginError"] = "Tiempo de sesión finalizó";
                    return Redirect("/Account/Login");
                }

                ViewBag.UsuarioEnSesion = usuarioEnSesion;
                var empresa = _infoEmpresaHelper.GetEmpresaById(id);

                if (empresa == null)
                {
                    ViewData["NoItemById"] = "No se ha encontrado la empresa";
                    return View(new InfoEmpresaViewModel());
                }

                ViewData["TiposIdentificacion"] = GetTiposIdentificacion();
                return View(empresa);
            }
            catch (Exception ex)
            {
                ViewData["ErrorItemById"] = $"Ocurrió un error al obtener la empresa: {ex.Message}";
                return View(new InfoEmpresaViewModel());
            }
        }

        [HttpPost]
        public IActionResult AgregarEmpresa(InfoEmpresaViewModel model)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }

            if (ModelState.IsValid)
            {
                _infoEmpresaHelper.AddEmpresa(model);
                TempData["NewEmpresa"] = model.Nombre;
                return Redirect("/InfoEmpresa/Index");
            }
            else
            {
                return Redirect("/InfoEmpresa/Index");
            }
        }


        [HttpPost]
        public IActionResult EditarEmpresa(InfoEmpresaViewModel model)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }

            if (ModelState.IsValid)
            {
                _infoEmpresaHelper.UpdateEmpresa(model);
                return Redirect("/InfoEmpresa/Index");
            }
            else
            {
                return Redirect("/InfoEmpresa/Index");
            }
        }


        [HttpPost]
        public IActionResult CambiarEstadoEmpresa(int id, bool inactivar)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }

            var empresa = _infoEmpresaHelper.GetEmpresaById(id);

            if (empresa != null)
            {
                _infoEmpresaHelper.UpdateEmpresa(empresa);
                return Redirect("/InfoEmpresa/Index");
            }
            else
            {
                return Redirect("/InfoEmpresa/Index");
            }
        }


        #region [Métodos]

        public List<TipoIdentificacion> GetTiposIdentificacion()
        {
            var tiposIdSesion = _HttpCA.HttpContext?.Session.GetString("TiposIdentificacion");

            if (tiposIdSesion == null)
            {
                var listadoTiposIdentificacion = _infoEmpresaHelper.GetTiposIdentificacion();

                if (listadoTiposIdentificacion != null)
                {
                    _HttpCA.HttpContext?.Session.SetString("TiposIdentificacion", JsonConvert.SerializeObject(listadoTiposIdentificacion));
                    return listadoTiposIdentificacion;
                }
                else
                {
                    return new List<TipoIdentificacion>();
                }
            }
            else
            {
                return JsonConvert.DeserializeObject<List<TipoIdentificacion>>(tiposIdSesion);
            }
        }

        #endregion
    }
}
