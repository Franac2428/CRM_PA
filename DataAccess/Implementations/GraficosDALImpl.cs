using DataAccess.Interfaces;
using Entities;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class GraficosDALImpl : DALGenericoImpl<GraficoModel>, IGraficosDAL
    {
        private CrmContext crm;

        public GraficosDALImpl(CrmContext crm) : base(crm)
        {
            this.crm = crm;
        }

    

    }
}
