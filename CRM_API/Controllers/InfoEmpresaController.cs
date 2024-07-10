using CRM_API.Model;
using CRM_API.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoEmpresaController : ControllerBase
    {
        IInfoEmpresaServices InfoEmpresa;

        public InfoEmpresaController(IInfoEmpresaServices infoEmpresaServices)
        {
            InfoEmpresa = infoEmpresaServices;
        }

        // GET: api/<InfoEmpresaController>
        [HttpGet]
        public IEnumerable<InfoEmpresaModel> Get()
        {
            return InfoEmpresa.GetInfoEmpresas();
        }

        // GET api/<InfoEmpresaController>/5
        [HttpGet("{id}")]
        public InfoEmpresaModel Get(int id)
        {
            return InfoEmpresa.GetById(id);
        }

        // POST api/<InfoEmpresaController>
        [HttpPost]
        public InfoEmpresaModel Post([FromBody] InfoEmpresaModel infoEmpresa)
        {
            InfoEmpresa.Add(infoEmpresa);
            return infoEmpresa;
        }

        // PUT api/<InfoEmpresaController>/5
        [HttpPut]
        public InfoEmpresaModel Put([FromBody] InfoEmpresaModel infoEmpresa)
        {
            InfoEmpresa.Update(infoEmpresa);
            return infoEmpresa;
        }

        // DELETE api/<InfoEmpresaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = InfoEmpresa.Delete(id);

            return new JsonResult(result);
        }
    }
}
