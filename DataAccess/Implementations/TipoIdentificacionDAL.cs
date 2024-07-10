using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class TipoIdentificacionDAL : DALGenericoImpl<TipoIdentificacion>, ITipoIdentificacionDAL
    {
        private CrmContext crm;

        public TipoIdentificacionDAL(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }
    }
}
