using CRM_API.Models;
using CRM_API.Services.Interfaces;
using E = Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecibosController : ControllerBase
    {
        private IRecibosSvc _svc;

        public RecibosController(IRecibosSvc svc)
        {
            _svc = svc;
        }

        #region [Metodos DAPPER]
        [HttpGet]
        public CRMResponse GetPagosRecibos()
        {
            var result = _svc.GetPagosRecibos();
            return result;
        }

        
        #endregion


       
    }
}
