using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class ServiciosController : Controller
    {

        IServiciosHelper ServicioHelper;
        private readonly IHttpContextAccessor _HttpCA;

        public ServiciosController(IServiciosHelper servicioHelper, IHttpContextAccessor httpCA)
        {
            ServicioHelper = servicioHelper;
            _HttpCA = httpCA;
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
                else
                {
                    ViewBag.UsuarioEnSesion = usuarioEnSesion;
                    var listadoServicios = ServicioHelper.GetServicios();

                    if (listadoServicios.Count == 0)
                    {
                        ViewData["NoDataList"] = "No existen datos para mostrar";
                        return View(new List<ServiciosViewModel>());
                    }
                    else
                    {
                        return View(listadoServicios);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorList"] = $"Ocurrió un error al listar la información: {ex}";
                return View(new List<ServiciosViewModel>());

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
            else
            {
                ViewBag.UsuarioEnSesion = usuarioEnSesion;
                var tiposIdentificacion = GetTiposIdentificacion();
                var tiposPlan = new List<TipoPlan>()
                {
                    new TipoPlan { IdTipoPlan = 1, Nombre = "Mensual" },
                    new TipoPlan { IdTipoPlan = 2, Nombre = "Anual" }
                };
                ViewData["TiposPlan"] = tiposPlan;
                ViewData["TiposIdentificacion"] = tiposIdentificacion;
                return View();
            }

            
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
                else
                {
                    ViewBag.UsuarioEnSesion = usuarioEnSesion;
                    var item = ServicioHelper.GetServicioById(id);
                    if (item == null)
                    {
                        ViewData["NoItemById"] = "No se ha encontrado el Servicio";
                        return View(new ServiciosViewModel());
                    }
                    else
                    {
                        var tiposMoneda = new List<TipoMoneda>()
                        {
                            new TipoMoneda { IdMoneda = 1, Nombre = "Colones" },
                            new TipoMoneda { IdMoneda = 2, Nombre = "Dolares" }
                        };
                        ViewData["tiposMoneda"] = tiposMoneda;
                        return View(item);
                    }
                }

                

            }
            catch (Exception ex)
            {
                ViewData["ErrorItemById"] = $"Ocurrió un error al obtener el item: {ex}";
                return View(new ServiciosViewModel());

            }
        }

        [HttpGet("[controller]/CambiarEstado/{id}/{inactivar}/{nombre}")]
        public IActionResult CambiarEstado(int id,bool inactivar,string nombre) 
        {
            var message = inactivar ? "inactivar" : "activar";

            try
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
                    ViewData["Message"] = message;
                    ViewData["ClientName"] = nombre;
                    ViewData["ClientId"] = id;
                    return View();
                }



            }
            catch (Exception ex)
            {
                ViewData["ErrorItemById"] = $"Ocurrió un error al obtener el item: {ex}";
                return View(new ServiciosViewModel());

            }
        }

        #region [Métodos]

        public List<TipoIdentificacion> GetTiposIdentificacion()
        {
            var tiposIdSesion = _HttpCA.HttpContext?.Session.GetString("TiposIdentificacion");

            if (tiposIdSesion == null)
            {
                var listadoServiciosTiposId = ServicioHelper.GetTiposMoneda();

                if (listadoServiciosTiposId != null)
                {
                    _HttpCA.HttpContext?.Session.SetString("TiposIdentificacion", JsonConvert.SerializeObject(listadoServiciosTiposId));
                    return listadoServiciosTiposId;
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

        [HttpPost]
        public IActionResult AgregarServicio(ServiciosViewModel model)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }
            else
            {
                var usuarioModel = JsonConvert.DeserializeObject<BeforeLoginModel>(usuarioEnSesion);
                

                if (ModelState.IsValid)
                {
                    model.Eliminado = false;
                    model.IdServicio = 1;
                    model.IdUsuarioCreacion = usuarioModel.Id;

                    ServicioHelper.AddServicio(model);
                    TempData["NewServicio"] = model.Nombre;
                    return Redirect("/Servicios/Index");
                }
                else
                {
                    return Redirect("/Servicios/Index");

                }
            }
        }

        [HttpPost]
        public IActionResult EditarServicio(ServiciosViewModel model)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }
            else
            {
                var usuarioModel = JsonConvert.DeserializeObject<BeforeLoginModel>(usuarioEnSesion);


                if (ModelState.IsValid)
                {
                    model.Eliminado = false;
                    model.IdUsuarioModificacion = usuarioModel.Id;
                    model.FechaModificacion = DateTime.Now;

                    ServicioHelper.UpdateServicio(model);
                    return Redirect("/Servicios/Index");
                }
                else
                {
                    return Redirect("/Servicios/Index");

                }
            }

        }

        [HttpPost]
        public IActionResult CambiarEstadoServicio(int id,bool inactivar)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }
            else
            {
                var usuarioModel = JsonConvert.DeserializeObject<BeforeLoginModel>(usuarioEnSesion);
                var item = ServicioHelper.GetServicioById(id);

                if(item != null)
                {
                    item.Eliminado = inactivar;
                    item.IdUsuarioModificacion = usuarioModel.Id;
                    item.FechaModificacion = DateTime.Now;

                    ServicioHelper.UpdateServicio(item);
                    return Redirect("/Servicios/Index");

                }
                else
                {
                    return Redirect("/Servicios/Index");
                }



            }

        }
        #endregion
    }
}
