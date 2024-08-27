using CRM_API.Model;
using CRM_API.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoEmpresaController : ControllerBase
    {
        private readonly IInfoEmpresaServices _infoEmpresaServices;

        public InfoEmpresaController(IInfoEmpresaServices infoEmpresaServices)
        {
            _infoEmpresaServices = infoEmpresaServices;
        }

        // GET: api/<InfoEmpresaController>
        [HttpGet]
        public ActionResult<IEnumerable<InfoEmpresaModel>> Get()
        {
            var empresas = _infoEmpresaServices.GetInfoEmpresas();

            if (empresas == null || !empresas.Any())
            {
                return NotFound("No se encontraron empresas.");
            }

            return Ok(empresas);
        }

        // GET api/<InfoEmpresaController>/5
        [HttpGet("{id}")]
        public ActionResult<InfoEmpresaModel> Get(int id)
        {
            var empresa = _infoEmpresaServices.GetById(id);

            if (empresa == null)
            {
                return NotFound($"Empresa con ID {id} no encontrada.");
            }

            return Ok(empresa);
        }

        // POST api/<InfoEmpresaController>
        [HttpPost]
        public ActionResult<InfoEmpresaModel> Post([FromBody] InfoEmpresaModel infoEmpresa)
        {
            if (infoEmpresa == null)
            {
                return BadRequest("Datos inválidos.");
            }

            _infoEmpresaServices.Add(infoEmpresa);

            return CreatedAtAction(nameof(Get), new { id = infoEmpresa.IdInfoEmpresa }, infoEmpresa);
        }

        // PUT api/<InfoEmpresaController>/5
        [HttpPut("{id}")]
        public InfoEmpresaModel Put([FromBody] InfoEmpresaModel infoEmpresa)
        {

            _infoEmpresaServices.Update(infoEmpresa);

            return infoEmpresa;
        }

        // DELETE api/<InfoEmpresaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingEmpresa = _infoEmpresaServices.GetById(id);
            if (existingEmpresa == null)
            {
                return NotFound($"Empresa con ID {id} no encontrada.");
            }

            var result = _infoEmpresaServices.Delete(id);

            if (result)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, "Ocurrió un error al eliminar la empresa.");
            }
        }
    }
}
