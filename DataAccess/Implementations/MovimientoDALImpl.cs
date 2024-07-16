using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class MovimientoDALImpl : DALGenericoImpl<Movimiento>, IMovimientoDAL
    {
        private CrmContext crm;

        public MovimientoDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
