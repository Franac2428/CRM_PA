using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = Entities;

namespace DataAccess
{
    public class RecibosDA
    {
        private readonly IConfiguration _configuration;

        public RecibosDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<E.ListaPagosModel> GetPagosRecibos()
        {
            using (var conn = new ConnManager(_configuration))
            {
                try
                {
                    var result = conn.CallStoredProcedureList<E.ListaPagosModel>("usp_ListarPagosRecibos");
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
