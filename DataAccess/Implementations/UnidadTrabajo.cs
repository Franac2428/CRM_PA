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

        private CrmContext _crm { get; set; }

        public UnidadTrabajo(CrmContext crm, IClienteDAL clienteDAL,ITipoIdentificacionDAL tipoIdentificacionDAL)
        {
            this._crm = crm;
            this.ClienteDAL = clienteDAL;
            this.TipoIdentificacionDAL = tipoIdentificacionDAL;
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
