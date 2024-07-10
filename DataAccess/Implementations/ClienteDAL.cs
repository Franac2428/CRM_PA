using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class ClienteDAL : DALGenericoImpl<Cliente>, IClienteDAL
    {
        private CrmContext crm;

        public ClienteDAL(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
