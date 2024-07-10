using DataAccess.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class EstadoMovimientoDALImpl : DALGenericoImpl<TipoEstadoMovimiento>, IEstadoMovimientoDAL
    {
        CrmContext context;
        public EstadoMovimientoDALImpl(CrmContext context) : base(context)
        {
            this.context = context;
        }
    }
}
