using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class TipoMovimientoDALImpl : DALGenericoImpl<TipoMovimiento>, ITipoMovimientoDAL
    {
        private CrmContext crm;

        public TipoMovimientoDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
