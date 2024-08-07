using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class MovimientoController : Controller
    {

        IMovimientosHelper MovimientosHelper;
        private readonly IHttpContextAccessor _HttpCA;

        public MovimientoController(IMovimientosHelper movimientosHelper, IHttpContextAccessor httpCA)
        {
            MovimientosHelper = movimientosHelper;
            _HttpCA = httpCA;
        }

        // GET: MovimientoController
        public IActionResult IndexSal()
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
                    var listadoMovimiento = MovimientosHelper.GetMovimientos();

                    if (listadoMovimiento.Count == 0)
                    {
                        ViewData["NoDataList"] = "No existen datos para mostrar";
                        return View(new List<MovimientosViewModel>());
                    }
                    else
                    {
                        return View(listadoMovimiento);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorList"] = $"Ocurrió un error al listar la información: {ex}";
                return View(new List<MovimientosViewModel>());

            }
        }

        public IActionResult IndexEnt()
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
                    var listadoMovimiento = MovimientosHelper.GetMovimientos();

                    if (listadoMovimiento.Count == 0)
                    {
                        ViewData["NoDataList"] = "No existen datos para mostrar";
                        return View(new List<MovimientosViewModel>());
                    }
                    else
                    {
                        return View(listadoMovimiento);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorList"] = $"Ocurrió un error al listar la información: {ex}";
                return View(new List<MovimientosViewModel>());

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
                    var item = MovimientosHelper.GetMovimientoByID(id);
                    if (item == null)
                    {
                        ViewData["NoItemById"] = "No se ha encontrado el cliente";
                        return View(new MovimientosViewModel());
                    }
                    else
                    {
                        var tipoMovimiento = new List<TipoEstadoMovimiento>()
                        {
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 1, Nombre = "Pendiente" },
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 2, Nombre = "Pagado" },
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 3, Nombre = "Anulado" }
                        };
                        ViewData["EstadoMovimiento"] = tipoMovimiento;
                        return View(item);
                    }
                }



            }
            catch (Exception ex)
            {
                ViewData["ErrorItemById"] = $"Ocurrió un error al obtener el item: {ex}";
                return View(new MovimientosViewModel());

            }
        }
        [HttpPost]
        public IActionResult AgregarMovSal(MovimientosViewModel model)
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
                    model.Imagen = null;
                    model.IdEstadoMovimiento = 1;
                    model.IdTipoMovimiento = 2;
                    model.IdUsuarioCreacion = usuarioModel.Id;

                    MovimientosHelper.AddSalEnt(model);
                    TempData["NewIDMov"] = model.IdMovimiento;
                    return Redirect("/Movimiento/Index");
                }
                else
                {
                    return Redirect("/Movimiento/Index");

                }
            }
        }
        [HttpPost]
        public IActionResult AgregarMovEnt(MovimientosViewModel model)
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
                    model.Imagen = null;
                    model.IdEstadoMovimiento = 1;
                    model.IdTipoMovimiento = 1;
                    model.IdUsuarioCreacion = usuarioModel.Id;

                    MovimientosHelper.AddSalEnt(model);
                    TempData["NewMovimieno"] = "Se agrego";
                    return Redirect("/Movimiento/IndexEnt");
                }
                else
                {
                    return Redirect("/Movimiento/IndexEnt");

                }
            }
        }

        [HttpPost]
        public IActionResult EditarMov(MovimientosViewModel model)
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
                    model.IdUsuarioModificacion = usuarioModel.Id;
                    model.FechaModificacion = DateTime.Now;

                    MovimientosHelper.Update(model);
                    return Redirect("/Movimiento/IndexEnt");
                }
                else
                {
                    return Redirect("/Movimiento/IndexEnt");

                }
            }

        }
    }
}

