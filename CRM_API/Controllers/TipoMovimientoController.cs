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
    public class TipoMovimientoController : ControllerBase
    {
        ITipoMovimientoServices TipoMovimiento;

        public TipoMovimientoController(ITipoMovimientoServices tipoMovimiento)
        {
            TipoMovimiento = tipoMovimiento;
        }

        // GET: api/<TipoMovimientoController>
        [HttpGet]
        public IEnumerable<TipoMovimientoModel> Get()
        {
            return TipoMovimiento.GetTipoMovimiento();
        }

        // GET api/<TipoMovimientoController>/5
        [HttpGet("{id}")]
        public TipoMovimientoModel Get(int id)
        {
            return TipoMovimiento.GetById(id);
        }

        // POST api/<TipoMovimientoController>
        [HttpPost]
        public TipoMovimientoModel Post([FromBody] TipoMovimientoModel tipoMovimiento)
        {
            TipoMovimiento.Add(tipoMovimiento);
            return tipoMovimiento;
        }

        // PUT api/<TipoMovimientoController>/5
        [HttpPut]
        public TipoMovimientoModel Put([FromBody] TipoMovimientoModel tipoMovimiento)
        {
            TipoMovimiento.Update(tipoMovimiento);
            return tipoMovimiento;
        }

        // DELETE api/<TipoMovimientoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = TipoMovimiento.Delete(id);

            return new JsonResult(result);
        }
    }
}
