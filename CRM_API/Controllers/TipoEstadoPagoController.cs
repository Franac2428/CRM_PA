using CRM_API.Models;
using CRM_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEstadoPagoController : ControllerBase
    {
        private ITipoEstadoPagoServices _tipoEstado;

        public TipoEstadoPagoController(ITipoEstadoPagoServices tipoEstado)
        {
            this._tipoEstado = tipoEstado;
        }

        // GET: api/<TipoEstadoPagoController>
        [HttpGet]
        public IEnumerable<TipoEstadoPagoModel> Get()
        {
            return _tipoEstado.Get();
        }

        // GET api/<TipoEstadoPagoController>/5
        [HttpGet("{id}")]
        public TipoEstadoPagoModel Get(int id)
        {
            return _tipoEstado.GetById(id);
        }

        // POST api/<TipoEstadoPagoController>
        [HttpPost]
        public TipoEstadoPagoModel Post([FromBody] TipoEstadoPagoModel tipoEstado)
        {
            _tipoEstado.Add(tipoEstado);
            return tipoEstado;
        }

        // PUT api/<TipoEstadoPagoController>/5
        [HttpPut]
        public TipoEstadoPagoModel Put([FromBody] TipoEstadoPagoModel tipoEstado)
        {
            _tipoEstado.Update(tipoEstado);
            return tipoEstado;
        }

        // DELETE api/<TipoEstadoPagoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TipoEstadoPagoModel tipoEstado = new TipoEstadoPagoModel { IdEstadoPago = id };
            _tipoEstado.Remove(tipoEstado);
        }
    }
}
