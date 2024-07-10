using CRM_API.Model;
using CRM_API.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoMovimientoController : ControllerBase
    {
        IEstadoMovimientoServices EstadoMovimiento;

        public EstadoMovimientoController(IEstadoMovimientoServices estadoMovimiento)
        {
            EstadoMovimiento = estadoMovimiento;
        }

        // GET: api/<EstadoMovimientoController>
        [HttpGet]
        public IEnumerable<EstadoMovimientoModel> Get()
        {
            return EstadoMovimiento.GetEstadoMovimientos();
        }

        // GET api/<EstadoMovimientoController>/5
        [HttpGet("{id}")]
        public EstadoMovimientoModel Get(int id)
        {
            return EstadoMovimiento.GetById(id);
        }

        // POST api/<EstadoMovimientoController>
        [HttpPost]
        public EstadoMovimientoModel Post([FromBody]  EstadoMovimientoModel estadoMovimiento)
        {
            EstadoMovimiento.Add(estadoMovimiento);
            return estadoMovimiento;
        }

        // PUT api/<EstadoMovimientoController>/5
        [HttpPut]
        public EstadoMovimientoModel Put([FromBody] EstadoMovimientoModel estadoMovimiento)
        {
            EstadoMovimiento.Update(estadoMovimiento);
            return estadoMovimiento;
        }

        // DELETE api/<EstadoMovimientoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = EstadoMovimiento.Delete(id);

            return new JsonResult(result);
        }
    }
}
