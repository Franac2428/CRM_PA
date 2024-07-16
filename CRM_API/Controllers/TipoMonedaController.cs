using CRM_API.Model;
using CRM_API.Models;
using CRM_API.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMonedaController : ControllerBase
    {
        ITipoMonedaServices TipoMoneda;

        public TipoMonedaController(ITipoMonedaServices tipoMoneda)
        {
            TipoMoneda = tipoMoneda;
        }

        // GET: api/<TipoMonedaController>
        [HttpGet]
        public IEnumerable<TipoMonedaModel> Get()
        {
            return TipoMoneda.GetTipoMoneda();
        }

        // GET api/<TipoMonedaController>/5
        [HttpGet("{id}")]
        public TipoMonedaModel Get(int id)
        {
            return TipoMoneda.GetById(id);
        }

        // POST api/<TipoMonedaController>
        [HttpPost]
        public TipoMonedaModel Post([FromBody] TipoMonedaModel tipoMoneda)
        {
            TipoMoneda.Add(tipoMoneda);
            return tipoMoneda;
        }

        // PUT api/<TipoMonedaController>/5
        [HttpPut]
        public TipoMonedaModel Put([FromBody] TipoMonedaModel tipoMoneda)
        {
            TipoMoneda.Update(tipoMoneda);
            return tipoMoneda;
        }

        // DELETE api/<TipoMonedaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = TipoMoneda.Delete(id);

            return new JsonResult(result);
        }
    }
}
