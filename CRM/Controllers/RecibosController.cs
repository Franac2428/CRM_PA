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
        IInfoEmpresaHelper InfoEmpresaHelper;
        IPagosHelper PagosHelper;

        public RecibosController(IHttpContextAccessor httpCA, IRecibosHelper helper, IInfoEmpresaHelper infoEmpresaHelper, IPagosHelper pagosHelper)
        {
            _HttpCA = httpCA;
            RecibosHelper = helper;
            InfoEmpresaHelper = infoEmpresaHelper;
            PagosHelper = pagosHelper;
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

        [HttpPost]
        [Route("Recibos/CancelarPago/{id}")]
        public IActionResult CancelarPago(int id)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }
            else
            {
                var result = RecibosHelper.CancelarPago(id);
                if (result.Status == "Success")
                {
                    //Obtenemos la info de la empresa:
                    var infoEmpresa = InfoEmpresaHelper.GetEmpresaById(1);
                    var infoPago = PagosHelper.GetPagoById(id);





                    return new JsonResult(new { Status = "success", data = result, InfoEmpresa = infoEmpresa, InfoPago = infoPago });
                }
                else
                {
                    return new JsonResult(new { Status = "failed", data = (object)null });
                }
            }
        }

        [HttpPost]
        [Route("Recibos/ReimprimirPago/{id}")]
        public IActionResult ReimprimirPago(int id)
        {
            var usuarioEnSesion = _HttpCA.HttpContext?.Session.GetString("UsuarioEnSesion");

            if (usuarioEnSesion == null)
            {
                TempData["LoginError"] = "Tiempo de sesión finalizó";
                return Redirect("/Account/Login");
            }
            else
            {

                var infoEmpresa = InfoEmpresaHelper.GetEmpresaById(1);
                var infoPago = PagosHelper.GetPagoById(id);

                if (infoEmpresa != null || infoPago != null)
                {
                    return new JsonResult(new { Status = "success", InfoEmpresa = infoEmpresa, InfoPago = infoPago });

                }
                else
                {
                    return new JsonResult(new { Status = "failed", data = (object)null });
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
