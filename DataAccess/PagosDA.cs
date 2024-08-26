using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PagosDA
    {
        private readonly IConfiguration _configuration;

        public PagosDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool PostPagos(FiltrosReportes model)
        {
            using (var conn = new ConnManager(_configuration))
            {
                try
                {
                    var param = new
                    {
                        FechaInicial = model.FechaInicial,
                        FechaFinal = model.FechaFinal,
                        IdUsuarioCreacion = model.IdUsuarioCreacion
                    };

                    var result = conn.CallStoredProcedure<GraficoModel>("usp_Generar_Pagos", param);

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public IEnumerable<ListaPagosModel> GetListaPagos(FiltrosReportes model)
        {
            using (var conn = new ConnManager(_configuration))
            {
                try
                {
                    var param = new
                    {
                        MesPago = model.MesPago,
                        NombreCliente = model.NombreCliente
                    };

                    var result = conn.CallStoredProcedureList<ListaPagosModel>("usp_Listar_Pagos", param);

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public VerPagoModel GetPagoById(int IdPago)
        {
            using (var conn = new ConnManager(_configuration))
            {
                try
                {
                    var param = new
                    {
                        IdPago = IdPago
                    };

                    var result = conn.CallStoredProcedure<VerPagoModel>("usp_ObtenerPago_ById", param);

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int AgregarEditarPago(RegistrarPagoModel model)
        {
            using (var conn = new ConnManager(_configuration))
            {
                try
                {
                    var param = new
                    {
                        IdPago = model.IdPago,
                        IdCliente = model.IdCliente,
                        MontoPago = model.MontoPago,
                        IdUsuarioCreacion = model.IdUsuarioCreacion,
                        IdUsuarioModificacion = model.IdUsuarioModificacion,
                        MesPago = model.MesPago,
                        IdEstadoPago = model.IdEstadoPago,
                        IdServicio = model.IdServicio,
                        ImagenComprobante = model.ImagenComprobante,
                        NumeroComprobannte = model.NumeroComprobannte,
                        TipoImagen = model.TipoImagen,
                        EnviadoAFacturar = model.EnviadoAFacturar,
                        PagaCon = model.PagaCon,
                        Comentario = model.Comentario
                    };

                    var r = conn.ExecStoredProcScalar<int>("usp_AgregarEditarPagos", param);

                    return r;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



    }
}
