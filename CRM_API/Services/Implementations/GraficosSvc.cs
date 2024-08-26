using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using Entities;

namespace CRM_API.Services.Implementations
{
    public class GraficosSvc : IGraficosSvc
    {
        private readonly GraficosDA _DA;

        public GraficosSvc(IConfiguration configuration)
        {
            _DA = new GraficosDA(configuration);
        }

        public GraficoModel GetGraficos()
        {
            try
            {
                var result = _DA.GetGraficos();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
