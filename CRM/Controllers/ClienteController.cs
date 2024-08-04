using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class ClienteController : Controller
    {

        IClienteHelper ClienteHelper;
        private readonly IHttpContextAccessor _HttpCA;

        public ClienteController(IClienteHelper clienteHelper, IHttpContextAccessor httpCA)
        {
            ClienteHelper = clienteHelper;
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
                    var listadoClientes = ClienteHelper.GetClientes();

                    if (listadoClientes.Count == 0)
                    {
                        ViewData["NoDataList"] = "No existen datos para mostrar";
                        return View(new List<ClienteViewModel>());
                    }
                    else
                    {
                        return View(listadoClientes);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorList"] = $"Ocurrió un error al listar la información: {ex}";
                return View(new List<ClienteViewModel>());

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
                    var item = ClienteHelper.GetClienteById(id);
                    if (item == null)
                    {
                        ViewData["NoItemById"] = "No se ha encontrado el cliente";
                        return View(new ClienteViewModel());
                    }
                    else
                    {
                        var tiposIdentificacion = GetTiposIdentificacion();
                        var tiposPlan = new List<TipoPlan>()
                        {
                            new TipoPlan { IdTipoPlan = 1, Nombre = "Mensual" },
                            new TipoPlan { IdTipoPlan = 2, Nombre = "Anual" }
                        };
                        ViewData["TiposPlan"] = tiposPlan;
                        ViewData["TiposIdentificacion"] = tiposIdentificacion;
                        return View(item);
                    }
                }

                

            }
            catch (Exception ex)
            {
                ViewData["ErrorItemById"] = $"Ocurrió un error al obtener el item: {ex}";
                return View(new ClienteViewModel());

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
                return View(new ClienteViewModel());

            }
        }

        #region [Métodos]

        public List<TipoIdentificacion> GetTiposIdentificacion()
        {
            var tiposIdSesion = _HttpCA.HttpContext?.Session.GetString("TiposIdentificacion");

            if (tiposIdSesion == null)
            {
                var listadoClientesTiposId = ClienteHelper.GetTiposIdentificacion();

                if (listadoClientesTiposId != null)
                {
                    _HttpCA.HttpContext?.Session.SetString("TiposIdentificacion", JsonConvert.SerializeObject(listadoClientesTiposId));
                    return listadoClientesTiposId;
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
        public IActionResult AgregarCliente(ClienteViewModel model)
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

                    ClienteHelper.AddCliente(model);
                    TempData["NewCliente"] = model.Nombre;
                    return Redirect("/Cliente/Index");
                }
                else
                {
                    return Redirect("/Cliente/Index");

                }
            }
        }

        [HttpPost]
        public IActionResult EditarCliente(ClienteViewModel model)
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

                    ClienteHelper.UpdateCliente(model);
                    return Redirect("/Cliente/Index");
                }
                else
                {
                    return Redirect("/Cliente/Index");

                }
            }

        }

        [HttpPost]
        public IActionResult CambiarEstadoCliente(int id,bool inactivar)
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
                var item = ClienteHelper.GetClienteById(id);

                if(item != null)
                {
                    item.Eliminado = inactivar;
                    item.IdUsuarioModificacion = usuarioModel.Id;
                    item.FechaModificacion = DateTime.Now;

                    ClienteHelper.UpdateCliente(item);
                    return Redirect("/Cliente/Index");

                }
                else
                {
                    return Redirect("/Cliente/Index");
                }



            }

        }
        #endregion
    }
}
