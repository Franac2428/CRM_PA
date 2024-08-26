using CRM_API.Models;
using CRM_API.Services.Interfaces;
using E = Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private IPagoSvc _svc;

        public PagoController(IPagoSvc svc)
        {
            _svc = svc;
        }

        #region [Metodos DAPPER]
        [HttpPost]
        public IEnumerable<ListaPagosModel> GetListaPagos([FromBody] E.FiltrosReportes model)
        {
            var result = _svc.GetListaPagos(model);
            return result;
        }

        [HttpGet("{id}")]
        public VerPagoModel GetPagoById(int id)
        {
            return _svc.GetPagoById(id);
        }


        #endregion


        public IEnumerable<PagoModel> Get()
        {
            return _svc.Get();
        }



        //[HttpPost]
        //public PagoModel Post([FromBody] PagoModel model)
        //{
        //    _svc.Add(model);
        //    return model;
        //}

        [HttpPut("{id}")]
        public PagoModel Put([FromBody] PagoModel model)
        {
            _svc.Update(model);
            return model;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PagoModel model = new PagoModel { IdCliente = id };
            _svc.Remove(model);
        }

        
    }
}
