using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult AgregarEnt()
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

        public IActionResult AgregarSal()
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

        public IActionResult EditarEnt(int id)
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
                        ViewData["NoItemById"] = "No se ha encontrado el movimiento";
                        return View(new MovimientosViewModel());
                    }
                    else
                    {
                        var tiposEstado = new List<TipoEstadoMovimiento>()
                        {
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 1, Nombre = "Pendiente" },
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 2, Nombre = "Pagado" },
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 3, Nombre = "Anulado" }
                        };
                        ViewData["TiposEstado"] = tiposEstado;
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

        public IActionResult EditarSal(int id)
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
                        ViewData["NoItemById"] = "No se ha encontrado el movimiento";
                        return View(new MovimientosViewModel());
                    }
                    else
                    {
                        var tiposEstado = new List<TipoEstadoMovimiento>()
                        {
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 1, Nombre = "Pendiente" },
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 2, Nombre = "Pagado" },
                            new TipoEstadoMovimiento { IdEstadoMovimiento = 3, Nombre = "Anulado" }
                        };
                        ViewData["TiposEstado"] = tiposEstado;
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

        #region [Métodos]

        public List<TipoEstadoMovimiento> GetTiposIdentificacion()
        {
            var tiposIdSesion = _HttpCA.HttpContext?.Session.GetString("TiposIdentificacion");

            if (tiposIdSesion == null)
            {
                var listadoClientesTiposId = MovimientosHelper.GetTipoEstado();

                if (listadoClientesTiposId != null)
                {
                    _HttpCA.HttpContext?.Session.SetString("TipoEstadoMovimiento", JsonConvert.SerializeObject(listadoClientesTiposId));
                    return listadoClientesTiposId;
                }
                else
                {
                    return new List<TipoEstadoMovimiento>();
                }
            }
            else
            {
                return JsonConvert.DeserializeObject<List<TipoEstadoMovimiento>>(tiposIdSesion);
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

                    _ = MovimientosHelper.AddSalEnt(model);
                    return Redirect("/Movimiento/IndexSal");
                }
                else
                {
                    return Redirect("/Movimiento/IndexSal");

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

                    _ = MovimientosHelper.AddSalEnt(model);
                    return Redirect("/Movimiento/IndexEnt");
                }
                else
                {
                    return Redirect("/Movimiento/IndexEnt");

                }
            }
        }

        [HttpPost]
        public IActionResult EditarMovEnt(MovimientosViewModel model)
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
                    model.IdUsuarioModificacion = usuarioModel.Id;
                    model.FechaModificacion = DateTime.Now;
                    model.IdTipoMovimiento = 1;
                    MovimientosHelper.UpdateMovimiento(model);
                    return Redirect("/Movimiento/IndexEnt");
                }
                else
                {
                    return Redirect("/Movimiento/IndexEnt");

                }
            }

        }

        [HttpPost]
        public IActionResult EditarMovSal(MovimientosViewModel model)
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
                    model.IdUsuarioModificacion = usuarioModel.Id;
                    model.FechaModificacion = DateTime.Now;
                    model.IdTipoMovimiento = 2;
                    MovimientosHelper.UpdateMovimiento(model);
                    return Redirect("/Movimiento/IndexSal");
                }
                else
                {
                    return Redirect("/Movimiento/IndexSal");

                }
            }

        }

        [HttpPost]
        public void SubirImagen(IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imagen.CopyToAsync(memoryStream);
                    byte[] imagenBytes = memoryStream.ToArray();
                    string tipoImagen = imagen.ContentType;

                    Console.WriteLine(imagen);

                    
                }


            }
            
        }




        #endregion
    }
}