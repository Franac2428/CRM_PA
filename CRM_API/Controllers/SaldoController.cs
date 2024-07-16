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
    public class SaldoController : ControllerBase
    {
        ISaldoServices Saldo;

        public SaldoController(ISaldoServices saldo)
        {
            Saldo = saldo;
        }

        // GET: api/<TipoMonedaController>
        [HttpGet]
        public IEnumerable<SaldoModel> Get()
        {
            return Saldo.GetSaldo();
        }

        // GET api/<TipoMonedaController>/5
        [HttpGet("{id}")]
        public SaldoModel Get(int id)
        {
            return Saldo.GetById(id);
        }

        // POST api/<TipoMonedaController>
        [HttpPost]
        public SaldoModel Post([FromBody] SaldoModel saldo)
        {
            Saldo.Add(saldo);
            return saldo;
        }

        // PUT api/<TipoMonedaController>/5
        [HttpPut]
        public SaldoModel Put([FromBody] SaldoModel saldo)
        {
            Saldo.Update(saldo);
            return saldo;
        }

        // DELETE api/<TipoMonedaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = Saldo.Delete(id);

            return new JsonResult(result);
        }
    }
}
