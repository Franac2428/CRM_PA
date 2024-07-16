using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class TipoMonedaDALImpl : DALGenericoImpl<TipoMoneda>, ITipoMonedaDAL
    {
        private CrmContext crm;

        public TipoMonedaDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
