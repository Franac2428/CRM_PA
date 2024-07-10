using CRM_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRM_API.Models;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIdentificacionController : ControllerBase
    {
        private ITipoIdentificacionSvc _svc;

        public TipoIdentificacionController(ITipoIdentificacionSvc svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public IEnumerable<TipoIdentificacionModel> Get()
        {
            return _svc.Get();
        }

        [HttpGet("{id}")]
        public TipoIdentificacionModel GetById(int id)
        {
            return _svc.GetById(id);
        }

        [HttpPost]
        public TipoIdentificacionModel Post([FromBody] TipoIdentificacionModel model)
        {
            _svc.Add(model);
            return model;
        }

        [HttpPut("{id}")]
        public TipoIdentificacionModel Put([FromBody] TipoIdentificacionModel model)
        {
            _svc.Update(model);
            return model;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TipoIdentificacionModel model = new TipoIdentificacionModel { IdTipoIdentificacion = id };
            _svc.Remove(model);
        }
    }
}
