using CRM_API.Models;
using CRM_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private IServiciosServicios _servicios;

        public ServiciosController(IServiciosServicios servicios)
        {
            this._servicios = servicios;
        }

        // GET: api/<ServiciosController>
        [HttpGet]
        public IEnumerable<ServiciosModel> Get()
        {
            return _servicios.Get();
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public ServiciosModel Get(int id)
        {
            return _servicios.GetById(id);
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public ServiciosModel Post([FromBody] ServiciosModel servicios)
        {
            _servicios.Add(servicios);
            return servicios;
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public ServiciosModel Put([FromBody] ServiciosModel servicios)
        {
            _servicios.Update(servicios);
            return servicios;
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ServiciosModel servicios = new ServiciosModel { IdServicio = id };
            _servicios.Remove(servicios);
        }
    }
}
