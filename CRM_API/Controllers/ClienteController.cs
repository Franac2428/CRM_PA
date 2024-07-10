using CRM_API.Models;
using CRM_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteSvc _svc;

        public ClienteController(IClienteSvc svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public IEnumerable<ClienteModel> Get()
        {
            return _svc.Get();
        }

        [HttpGet("{id}")]
        public ClienteModel GetById(int id)
        {
            return _svc.GetById(id);
        }

        [HttpPost]
        public ClienteModel Post([FromBody] ClienteModel model)
        {
            _svc.Add(model);
            return model;
        }

        [HttpPut("{id}")]
        public ClienteModel Put([FromBody] ClienteModel model)
        {
            _svc.Update(model);
            return model;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ClienteModel model = new ClienteModel { IdCliente = id };
            _svc.Remove(model);
        }
    }
}
