using Dapper;
using Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GraficosDA
    {
        private readonly IConfiguration _configuration;

        public GraficosDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GraficoModel GetGraficos()
        {
            using (var conn = new ConnManager(_configuration))
            {
                try
                {
                    var model = new GraficoModel();

                    using (var aux = conn.AuxConn())
                    {
                        using (var multi = aux.QueryMultiple("usp_Grafico_Movimientos", commandType: CommandType.StoredProcedure))
                        {

                            model.Movimientos = multi.ReadSingle<GraficoMovimientos>();

                            model.GraficoPagos = multi.Read<GraficoPagosModel>().ToList();

                            model.GraficoPagosDolares = multi.Read<GraficoPagosModel>().ToList();


                            aux.Close();

                        }

                    }
                    return model;

                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw ex;
                }
            }
        }






    }
}
