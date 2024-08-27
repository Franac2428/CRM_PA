using AM = CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using Entities.Entities;
using System.Collections.Generic;
using CRM_API.Models;
using E = Entities;
using System.Collections;

namespace CRM_API.Services.Implementations
{
    public class RecibosSvc : IRecibosSvc
    {
        private IUnidadTrabajo _ut;
        private readonly RecibosDA _DA;


        public RecibosSvc(IUnidadTrabajo ut, IConfiguration configuration)
        {
            this._ut = ut;
            _DA = new RecibosDA(configuration);
        }



        #region [Métodos DAPPER]

        public AM.CRMResponse GetPagosRecibos()
        {
            try
            {
                var result = _DA.GetPagosRecibos();
                List<AM.ListaPagosModel> lista = new List<AM.ListaPagosModel>();

                if (result == null || result.Count() == 0) {
                    return new CRMResponse()
                    {
                        Codigo = 400,
                        Mensaje = "No hay pagos para facturar",
                        Status = "Failed",
                        Data = null
                    };
                }
                else
                {
                    foreach (var item in result)
                    {
                        lista.Add(ConvertList(item));
                    }

                    return new CRMResponse()
                    {
                        Codigo = 200,
                        Mensaje = "Se han obtenido los pagos correctamente",
                        Status = "Success",
                        Data = lista
                    };
                }

                

                

            }
            catch (Exception ex)
            {
                return new CRMResponse()
                {
                    Codigo = 400,
                    Mensaje = ex.Message,
                    Status = "Failed",
                    Data = null
                };
            }
        }

        public AM.CRMResponse CancelarPago(int IdPago)
        {
            try
            {
                var result = _DA.CancelarPago(IdPago);

                return new CRMResponse()
                {
                    Codigo = 200,
                    Data = result,
                    Status = "Success"
                };

            }
            catch (Exception ex)
            {
                return new CRMResponse()
                {
                    Codigo = 400,
                    Data = null,
                    Status = "Failed"
                };
            }
        }


        #endregion



        #region [Conversión de entidades]
        private Pago Convert(AM.PagoModel model)
        {
            return new Pago
            {
                IdPago = model.IdPago,
                IdCliente = model.IdCliente,
                MontoPago = model.MontoPago,
                FechaCreacion = model.FechaCreacion,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                FechaModificacion = model.FechaModificacion,
                IdUsuarioModificacion = model.IdUsuarioModificacion,
                MesPago = model.MesPago,
                IdEstadoPago = model.IdEstadoPago,
                IdServicio = model.IdServicio,
                Comentario = model.Comentario,
                NumeroComprobannte = model.NumeroComprobannte,
                ImagenComprobante = model.ImagenComprobante,
                Eliminado = model.Eliminado
            };
        }

        private AM.PagoModel Convert(Pago model)
        {
            return new AM.PagoModel
            {
                IdPago = model.IdPago,
                IdCliente = model.IdCliente,
                MontoPago = model.MontoPago,
                FechaCreacion = model.FechaCreacion,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                FechaModificacion = model.FechaModificacion,
                IdUsuarioModificacion = model.IdUsuarioModificacion,
                MesPago = model.MesPago,
                IdEstadoPago = model.IdEstadoPago,
                IdServicio = model.IdServicio,
                Comentario = model.Comentario,
                NumeroComprobannte = model.NumeroComprobannte,
                ImagenComprobante = model.ImagenComprobante,
                Eliminado = model.Eliminado
            };
        }




        private E.ListaPagosModel ConvertList(AM.ListaPagosModel model)
        {
            return new E.ListaPagosModel()
            {
                IdPago = model.IdPago,
                IdCliente = model.IdCliente,
                NombreCliente = model.NombreCliente,
                MontoPago = model.MontoPago,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                NombreUsuario = model.NombreUsuario,
                FechaCreacion = model.FechaCreacion,
                MesPago = model.MesPago,
                IdEstadoPago = model.IdEstadoPago,
                EstadoPago = model.EstadoPago,
                IdServicio = model.IdServicio,
                NombreServicio = model.NombreServicio,
                Eliminado = model.Eliminado,
                IdSaldo = model.IdSaldo,
                MontoSaldo = model.MontoSaldo,
                IdMoneda = model.IdMoneda

            };
        }

        private AM.ListaPagosModel ConvertList(E.ListaPagosModel model)
        {
            return new AM.ListaPagosModel()
            {
                IdPago = model.IdPago,
                IdCliente = model.IdCliente,
                NombreCliente = model.NombreCliente,
                MontoPago = model.MontoPago,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                NombreUsuario = model.NombreUsuario,
                FechaCreacion = model.FechaCreacion,
                MesPago = model.MesPago,
                IdEstadoPago = model.IdEstadoPago,
                EstadoPago = model.EstadoPago,
                IdServicio = model.IdServicio,
                NombreServicio = model.NombreServicio,
                Eliminado = model.Eliminado,
                IdSaldo = model.IdSaldo,
                MontoSaldo = model.MontoSaldo,
                IdMoneda = model.IdMoneda

            };
        }

        private VerPagoModel ConvertVerPago(AM.VerPagoModel model)
        {
            return new VerPagoModel()
            {
                IdPago = model.IdPago,
                IdCliente = model.IdCliente,
                NombreCliente = model.NombreCliente,
                MontoPago = model.MontoPago,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                NombreUsuario = model.NombreUsuario,
                FechaCreacion = model.FechaCreacion,
                MesPago = model.MesPago,
                IdEstadoPago = model.IdEstadoPago,
                EstadoPago = model.EstadoPago,
                IdServicio = model.IdServicio,
                NombreServicio = model.NombreServicio,
                Eliminado = model.Eliminado,
                ImagenComprobante = model.ImagenComprobante,
                TipoImagen = model.TipoImagen,
                NumeroComprobannte = model.NumeroComprobannte,
                EnviadoAFacturar = model.EnviadoAFacturar,
                PagaCon = model.PagaCon,
                Comentario = model.Comentario,

            };
        }

        private AM.VerPagoModel ConvertVerPago(E.VerPagoModel model)
        {
            return new AM.VerPagoModel()
            {
                IdPago = model.IdPago,
                IdCliente = model.IdCliente,
                NombreCliente = model.NombreCliente,
                MontoPago = model.MontoPago,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                NombreUsuario = model.NombreUsuario,
                FechaCreacion = model.FechaCreacion,
                MesPago = model.MesPago,
                IdEstadoPago = model.IdEstadoPago,
                EstadoPago = model.EstadoPago,
                IdServicio = model.IdServicio,
                NombreServicio = model.NombreServicio,
                Eliminado = model.Eliminado,
                ImagenComprobante = model.ImagenComprobante,
                TipoImagen = model.TipoImagen,
                NumeroComprobannte = model.NumeroComprobannte,
                EnviadoAFacturar = model.EnviadoAFacturar,
                PagaCon = model.PagaCon,
                Comentario = model.Comentario,
            };
        }
        
        #endregion
    }
}
