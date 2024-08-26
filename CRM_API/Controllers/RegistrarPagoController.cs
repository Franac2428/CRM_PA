using CRM_API.Models;
using CRM_API.Services.Interfaces;
using E = Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarPagoController : ControllerBase
    {
        private IPagoSvc _svc;

        public RegistrarPagoController(IPagoSvc svc)
        {
            _svc = svc;
        }

        #region [Metodos DAPPER]
        [HttpPost]
        public CRMResponse AgregarEditarPago([FromBody] E.RegistrarPagoModel model)
        {
            var result = _svc.AgregarEditarPago(model);
            return result;
        }
        #endregion


       
        
    }
}
