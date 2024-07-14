using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DataAccess.Implementations
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        public IClienteDAL ClienteDAL { get; set; }
        public ITipoIdentificacionDAL TipoIdentificacionDAL { get; set; }

        public IEstadoMovimientoDAL EstadoMovimientoDAL { get; set; }

        public IInfoEmpresaDAL InfoEmpresaDAL { get; set; }

        public ITipoEstadoPagoDAL TipoEstadoPago { get; set; }

        public IServiciosDAL ServiciosDAL { get; set; }

        public ITipoEstadoPagoDAL TipoEstadoPagoDAL { get; set; }


        private CrmContext _crm { get; set; }

        public UnidadTrabajo(CrmContext crm, IClienteDAL clienteDAL,ITipoIdentificacionDAL TipoIdentificacionDAL, IEstadoMovimientoDAL estadoMovimientoDAL, IInfoEmpresaDAL infoEmpresaDAL, IServiciosDAL ServiciosDAL, ITipoEstadoPagoDAL TipoEstadoPagoDAL)
        {
            this._crm = crm;
            this.ClienteDAL = clienteDAL;
            this.EstadoMovimientoDAL = estadoMovimientoDAL;
            this.InfoEmpresaDAL = infoEmpresaDAL;
            this.TipoEstadoPago = TipoEstadoPago;
            this.ServiciosDAL = ServiciosDAL;
            this.TipoEstadoPagoDAL = TipoEstadoPagoDAL;
        }

        public bool Complete()
        {
            try
            {
                _crm.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._crm.Dispose();
        }
    }
}
