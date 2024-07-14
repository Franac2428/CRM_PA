using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class TipoEstadoPagoDALImpl : DALGenericoImpl<TipoEstadoPago>, ITipoEstadoPagoDAL
    {
        private CrmContext crm;
        public TipoEstadoPagoDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
