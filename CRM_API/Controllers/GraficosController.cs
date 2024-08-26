using CRM_API.Services.Implementations;
using CRM_API.Services.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraficosController : Controller
    {
        private  IGraficosSvc _SVC;

        public GraficosController(IConfiguration configuration)
        {
            _SVC = new GraficosSvc(configuration);
        }

        [HttpGet]
        public GraficoModel GetGraficos()
        {
            try
            {
                var result = _SVC.GetGraficos();
                return result;
            }
            catch (Exception ex) {
                throw ex;
            }
        }




    }
}
