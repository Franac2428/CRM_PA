using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class SaldoDALImpl : DALGenericoImpl<Saldo>, ISaldoDAL
    {
        private CrmContext crm;

        public SaldoDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
