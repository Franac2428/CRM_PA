using AM = CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using E = Entities;
using Entities.Entities;
using System.Collections.Generic;
using CRM_API.Models;

namespace CRM_API.Services.Implementations
{
    public class PagoSvc : IPagoSvc
    {
        private IUnidadTrabajo _ut;

        private IPagoDAL _DAL;

        private readonly PagosDA _DA;


        public PagoSvc(IUnidadTrabajo ut, IConfiguration configuration)
        {
            this._ut = ut;
            _DA = new PagosDA(configuration);
        }

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


        #endregion


        #region [Métodos DAPPER]

        public IEnumerable<AM.ListaPagosModel> GetListaPagos(E.FiltrosReportes model)
        {
            try
            {
                var result = _DA.GetListaPagos(model);
                List<AM.ListaPagosModel> lista = new List<AM.ListaPagosModel>();

                foreach (var item in result)
                {
                    lista.Add(ConvertList(item));
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AM.VerPagoModel GetPagoById(int IdPago)
        {
            try
            {
                var result = _DA.GetPagoById(IdPago);
                return ConvertVerPago(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CRMResponse AgregarEditarPago(E.RegistrarPagoModel model)
        {
            try
            {
                var result = _DA.AgregarEditarPago(model);

                return new CRMResponse()
                {
                    Codigo = 200,
                    Data = result,
                    Status = "Success"
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public CRMResponse GenerarPagos(E.FiltrosReportes model)
        {
            try
            {
                var result = _DA.PostPagos(model);

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
                    Status = "Failed",
                    Mensaje = ex.ToString()
                };
            }
        }


        #endregion



        public bool Add(AM.PagoModel model)
        {
            return _ut.PagoDAL.Add(Convert(model));
        }

        public AM.PagoModel GetById(int id)
        {
            return Convert(_ut.PagoDAL.GetById(id));
        }

        public IEnumerable<AM.PagoModel> Get()
        {
            var lista = _ut.PagoDAL.GetAll();
            List<AM.PagoModel> c = new List<AM.PagoModel>();
            foreach (var item in lista)
            {
                c.Add(Convert(item));
            }
            return c;
        }

        public bool Remove(AM.PagoModel model)
        {
            return _ut.PagoDAL.Remove(Convert(model));
        }

        public bool Update(AM.PagoModel model)
        {
            return _ut.PagoDAL.Update(Convert(model));
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
                IdMoneda = model.IdMoneda,
                EnviadoAFacturar = model.EnviadoAFacturar,

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
                IdMoneda = model.IdMoneda,
                EnviadoAFacturar = model.EnviadoAFacturar,

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
    }
}
