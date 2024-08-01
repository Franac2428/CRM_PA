using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
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
            catch (Exception ex)
            {
                ViewData["ErrorList"] = $"Ocurrió un error al listar la información: {ex}";
                return View(new List<ClienteViewModel>());

            }

        }

        public IActionResult Agregar()
        {
            var tiposIdentificacion = GetTiposIdentificacion();
            ViewData["TiposIdentificacion"] = tiposIdentificacion;
            return View();
        }

        public IActionResult Editar(int id)
        {
            try
            {
                var item = ClienteHelper.GetClienteById(id);
                if (item == null)
                {
                    ViewData["NoItemById"] = "No se ha encontrado el cliente";
                    return View(new ClienteViewModel());
                }
                else
                {
                    var tiposIdentificacion = GetTiposIdentificacion();
                    ViewData["TiposIdentificacion"] = tiposIdentificacion;
                    return View(item);
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
            if (ModelState.IsValid)
            {
                model.Eliminado = false;

                ClienteHelper.AddCliente(model);
                return Redirect("/Cliente/Index");
            }


            return Redirect("/Cliente/Index");
        }

        [HttpPost]
        public IActionResult EditarCliente(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Eliminado = false;

                ClienteHelper.UpdateCliente(model);
                return Redirect("/Cliente/Index");
            }


            return Redirect("/Cliente/Index");
        }

        #endregion
    }
}
