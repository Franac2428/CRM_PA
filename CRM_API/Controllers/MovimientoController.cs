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
    public class MovimientoController : ControllerBase
    {
        IMovimientoServices Movimiento;

        public MovimientoController(IMovimientoServices movimiento)
        {
            Movimiento = movimiento;
        }

        // GET: api/<MovimientoController>
        [HttpGet]
        public IEnumerable<MovimientoModel> Get()
        {
            return Movimiento.GetMovimiento();
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public MovimientoModel Get(int id)
        {
            return Movimiento.GetById(id);
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public MovimientoModel Post([FromBody] MovimientoModel movimiento)
        {
            Movimiento.Add(movimiento);
            return movimiento;
        }

        // PUT api/<MovimientoController>/5
        [HttpPut("{id}")]
        public MovimientoModel Put([FromBody] MovimientoModel movimiento)
        {
            Movimiento.Update(movimiento);
            return movimiento;
        }

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MovimientoModel model = new MovimientoModel { IdMovimiento = id };
            Movimiento.Delete(model);
        }
    }
}
