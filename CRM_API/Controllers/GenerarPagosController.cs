using CRM_API.Models;
using CRM_API.Services.Interfaces;
using E = Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarPagosController : ControllerBase
    {
        private IPagoSvc _svc;

        public GenerarPagosController(IPagoSvc svc)
        {
            _svc = svc;
        }

        #region [Metodos DAPPER]
        [HttpPost]
        public CRMResponse GenerarPagos([FromBody] E.FiltrosReportes model)
        {
            var result = _svc.GenerarPagos(model);
            return result;
        }
        #endregion


       
        
    }
}
