using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using E = Entities;
using EN = Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRM.APIModels;
using System;
using CRM.Entities;
using Entities.Entities;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    public class PagosController : Controller
    {
        IPagosHelper PagosHelper;
        private readonly IHttpContextAccessor _HttpCA;

        public PagosController(IHttpContextAccessor httpCA, IPagosHelper pagosHelper)
        {
            _HttpCA = httpCA;
            PagosHelper = pagosHelper;
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

                FiltrosReportes model = new FiltrosReportes()
                {
                    MesPago = null
                };



                var listaPagos = PagosHelper.GetListaPagos(ConvertMethod(model));

                if(listaPagos.Count == 0 || listaPagos == null)
                {
                    ViewData["NoDataList"] = "No existen datos para mostrar";
                    return View(new List<ListaPagosViewModel>());
                }
                else
                {
                    return View(listaPagos);
                }

            }

        }

        public IActionResult Editar(int id)
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

                var pago = PagosHelper.GetPagoById(id);

                if (pago == null)
                {
                    ViewData["NoItemById"] = "No existen datos para mostrar";
                    return View(new VerPagoViewModel());
                }
                else
                {
                    //Obtener Clientes
                    var clientes = PagosHelper.GetClientes().Where(c => c.Eliminado == false).ToList();
                    var servicios = PagosHelper.GetServicios().Where(s => s.Eliminado == false).ToList();

                    var tipoEstadoPago = new List<EN.TipoEstadoPago>()
                    {
                        new EN.TipoEstadoPago { IdEstadoPago = 1, Nombre = "Pendiente" },
                        new EN.TipoEstadoPago { IdEstadoPago = 3, Nombre = "Vencido" },
                        new EN.TipoEstadoPago { IdEstadoPago = 4, Nombre = "Anulado" },
                    };

                    var estadosFacturacion = new Dictionary<string, bool>
                    {
                        { "No Facturar", false },
                        { "Enviado A Facturar", true }
                    };

                    if(pago.ImagenComprobante != null && pago.TipoImagen != null)
                    {
                        string base64Image = Convert.ToBase64String(pago.ImagenComprobante);
                        string imageDataUrl = $"data:{pago.TipoImagen};base64,{base64Image}";
                        ViewData["UrlImagenComprobante"] = imageDataUrl;
                    }


                    ViewData["TipoEstadosPago"] = tipoEstadoPago;
                    ViewData["ClientesCatalogos"] = clientes;
                    ViewData["ServiciosCatalogos"] = servicios;
                    ViewData["EstadosFactCatalogos"] = estadosFacturacion;
                    return View(pago);
                }

            }

        }

        public IActionResult VerPago(int id)
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

                var pago = PagosHelper.GetPagoById(id);

                if (pago == null)
                {
                    ViewData["NoItemById"] = "No existen datos para mostrar";
                    return View(new VerPagoViewModel());
                }
                else
                {
                    //Obtener Clientes
                    var clientes = PagosHelper.GetClientes().Where(c => c.Eliminado == false).ToList();
                    var servicios = PagosHelper.GetServicios().Where(s => s.Eliminado == false).ToList();

                    var tipoEstadoPago = new List<EN.TipoEstadoPago>()
                    {
                        new EN.TipoEstadoPago { IdEstadoPago = 1, Nombre = "Pendiente" },
                        new EN.TipoEstadoPago { IdEstadoPago = 2, Nombre = "Cancelado" },
                        new EN.TipoEstadoPago { IdEstadoPago = 3, Nombre = "Vencido" },
                        new EN.TipoEstadoPago { IdEstadoPago = 4, Nombre = "Anulado" },
                    };

                    var estadosFacturacion = new Dictionary<string, bool>
                    {
                        { "No Facturar", false },
                        { "Enviado A Facturar", true }
                    };

                    if (pago.ImagenComprobante != null && pago.TipoImagen != null)
                    {
                        string base64Image = Convert.ToBase64String(pago.ImagenComprobante);
                        string imageDataUrl = $"data:{pago.TipoImagen};base64,{base64Image}";
                        ViewData["UrlImagenComprobante"] = imageDataUrl;
                    }


                    ViewData["TipoEstadosPago"] = tipoEstadoPago;
                    ViewData["ClientesCatalogos"] = clientes;
                    ViewData["ServiciosCatalogos"] = servicios;
                    ViewData["EstadosFactCatalogos"] = estadosFacturacion;
                    return View(pago);
                }

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

                //Obtener Clientes
                var clientes = PagosHelper.GetClientes().Where(c => c.Eliminado == false).ToList();
                var servicios = PagosHelper.GetServicios().Where(s => s.Eliminado == false).ToList();




                var tipoEstadoPago = new List<EN.TipoEstadoPago>()
                {
                    new EN.TipoEstadoPago { IdEstadoPago = 1, Nombre = "Pendiente" },
                    new EN.TipoEstadoPago { IdEstadoPago = 3, Nombre = "Vencido" },
                    new EN.TipoEstadoPago { IdEstadoPago = 4, Nombre = "Anulado" },

                };

                var estadosFacturacion = new Dictionary<string, bool>
                {
                    { "No facturar", false },
                    { "Enviado A Facturar", true }
                };

                ViewData["TipoEstadosPago"] = tipoEstadoPago;
                ViewData["ClientesCatalogos"] = clientes;
                ViewData["ServiciosCatalogos"] = servicios;
                ViewData["EstadosFactCatalogos"] = estadosFacturacion;
                return View();
            }
        }

        public IActionResult GenerarPagosClientes()
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


        [HttpPost]
        public async Task<IActionResult> RegistrarPago(RegistrarPagoModel model)
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
                if(model.IdPago != 0 || model.IdPago != null)
                {
                    model.IdUsuarioModificacion = usuarioModel.Id;
                }
                else
                {
                    model.IdUsuarioCreacion = usuarioModel.Id;
                }


                if (Request.Form.Files.Count > 0 && model.ImagenComprobante == null)
                {
                    var file = Request.Form.Files[0];

                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        model.ImagenComprobante = memoryStream.ToArray();
                        model.TipoImagen = file.ContentType;
                    }
                }

                var result = PagosHelper.AgregarEditarPago(model);

                if(model.IdPago == 0)
                {
                    TempData["SuccessAction"] = "Pago creado exitosamente";
                }
                else
                {
                    TempData["SuccessAction"] = "Pago actualizado exitosamente";

                }

                return RedirectToAction("Index", "Pagos");
                
            }
             
        }

        public E.FiltrosReportes ConvertMethod(FiltrosReportes m)
        {
            return new E.FiltrosReportes()
            {
                FechaInicial = m.FechaInicial,
                FechaFinal = m.FechaFinal,
                IdUsuarioCreacion = m.IdUsuarioCreacion,
                MesPago = m.MesPago,
                NombreCliente = m.NombreCliente
            };
        }

        public FiltrosReportes ConvertMethod(E.FiltrosReportes m)
        {
            return new FiltrosReportes()
            {
                FechaInicial = m.FechaInicial,
                FechaFinal = m.FechaFinal,
                IdUsuarioCreacion = m.IdUsuarioCreacion,
                MesPago = m.MesPago,
                NombreCliente = m.NombreCliente
            };
        }

        [HttpPost]
        public async Task<IActionResult> GenerarPagos(FiltrosReportes model)
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
                model.IdUsuarioCreacion = usuarioModel.Id;

             
                var result = PagosHelper.GenerarPagos(model);

                if(result.Status == "Failed")
                {
                    TempData["ErrorGeneratePagos"] = "Ya existen pagos generados para el mes indicado";
                    return RedirectToAction("Index", "Pagos");
                }
                else
                {
                    TempData["SuccessGeneratePagos"] = "Pagos generados satisfactoriamente";
                    return RedirectToAction("Index", "Pagos");
                }

            }

        }



    }
}
