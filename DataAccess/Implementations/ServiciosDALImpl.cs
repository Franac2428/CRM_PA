using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class ServiciosDALImpl : DALGenericoImpl<Servicio>, IServiciosDAL
    {
        private CrmContext crm;
        public ServiciosDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
