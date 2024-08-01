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

        public ISaldoDAL SaldoDAL { get; set; }

        public ITipoMonedaDAL TipoMonedaDAL { get; set; }
        public IMovimientoDAL MovimientoDAL { get; set; }
        public ITipoMovimientoDAL TipoMovimientoDAL { get; set; }

        private CrmContext _crm { get; set; }

        public UnidadTrabajo(CrmContext crm, IClienteDAL clienteDAL,ITipoIdentificacionDAL TipoIdentificacionDAL, IEstadoMovimientoDAL estadoMovimientoDAL, IInfoEmpresaDAL infoEmpresaDAL, IServiciosDAL ServiciosDAL, ITipoEstadoPagoDAL TipoEstadoPagoDAL, ISaldoDAL SaldoDAL, ITipoMonedaDAL TipoMonedaDAL, IMovimientoDAL MovimientoDAL, ITipoMovimientoDAL TipoMovimientoDAL)
        {
            this._crm = crm;
            this.ClienteDAL = clienteDAL;
            this.EstadoMovimientoDAL = estadoMovimientoDAL;
            this.InfoEmpresaDAL = infoEmpresaDAL;
            this.TipoEstadoPago = TipoEstadoPagoDAL;
            this.ServiciosDAL = ServiciosDAL;
            this.TipoEstadoPagoDAL = TipoEstadoPagoDAL;
            this.SaldoDAL = SaldoDAL;
            this.TipoMonedaDAL = TipoMonedaDAL;
            this.MovimientoDAL = MovimientoDAL;
            this.TipoMovimientoDAL = TipoMovimientoDAL;
            this.TipoIdentificacionDAL = TipoIdentificacionDAL;
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
