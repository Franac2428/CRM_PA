using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace CRM.Controllers
{
    public class RecibosController : Controller
    {
        private readonly IHttpContextAccessor _HttpCA;
        IRecibosHelper RecibosHelper;

        public RecibosController(IHttpContextAccessor httpCA,IRecibosHelper helper)
        {
            _HttpCA = httpCA;
            RecibosHelper = helper;
        }
        public IActionResult Index()
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

                var result = RecibosHelper.GetPagosRecibos();

                if (result.Status == "Success")
                {
                    var listadoPagos = JsonConvert.DeserializeObject<List<ListaPagosViewModel>>(result.Data.ToString());

                    return View(listadoPagos);
                }
                else
                {
                    ViewData["NoDataList"] = result.Mensaje;
                    return View(new List<ListaPagosViewModel>());
                }


            }
        }


        #region [CONVERTIR MODELS]
        private ListaPagosModel Convert(ListaPagosViewModel viewModel)
        {
            return new ListaPagosModel
            {
                IdPago = viewModel.IdPago,
                IdCliente = viewModel.IdCliente,
                NombreCliente = viewModel.NombreCliente,
                MontoPago = viewModel.MontoPago,
                IdUsuarioCreacion = viewModel.IdUsuarioCreacion,
                NombreUsuario = viewModel.NombreUsuario,
                FechaCreacion = viewModel.FechaCreacion,
                MesPago = viewModel.MesPago,
                IdEstadoPago = viewModel.IdEstadoPago,
                EstadoPago = viewModel.EstadoPago,
                IdServicio = viewModel.IdServicio,
                NombreServicio = viewModel.NombreServicio,
                Eliminado = viewModel.Eliminado,
                IdSaldo = viewModel.IdSaldo,
                MontoSaldo = viewModel.MontoSaldo,
                IdTipoPlan = viewModel.IdTipoPlan,
                IdMoneda = viewModel.IdMoneda
            };
        }

        private ListaPagosViewModel Convert(ListaPagosModel viewModel)
        {
            return new ListaPagosViewModel
            {
                IdPago = viewModel.IdPago,
                IdCliente = viewModel.IdCliente,
                NombreCliente = viewModel.NombreCliente,
                MontoPago = viewModel.MontoPago,
                IdUsuarioCreacion = viewModel.IdUsuarioCreacion,
                NombreUsuario = viewModel.NombreUsuario,
                FechaCreacion = viewModel.FechaCreacion,
                MesPago = viewModel.MesPago,
                IdEstadoPago = viewModel.IdEstadoPago,
                EstadoPago = viewModel.EstadoPago,
                IdServicio = viewModel.IdServicio,
                NombreServicio = viewModel.NombreServicio,
                Eliminado = viewModel.Eliminado,
                IdSaldo = viewModel.IdSaldo,
                MontoSaldo = viewModel.MontoSaldo,
                IdTipoPlan = viewModel.IdTipoPlan,
                IdMoneda = viewModel.IdMoneda
            };
        }

        #endregion
    }
}
