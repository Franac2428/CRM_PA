using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class PagoDALImpl : DALGenericoImpl<Pago>, IPagoDAL
    {
        private CrmContext crm;

        public PagoDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }

        

    }
}
