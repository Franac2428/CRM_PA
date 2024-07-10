using CRM_API.Models;
using Entities.Entities;

namespace CRM_API.Services.Interfaces
{
    public interface IClienteSvc
    {
        bool Add(ClienteModel category);
        bool Remove(ClienteModel category);
        bool Update(ClienteModel category);
        ClienteModel GetById(int id);
        IEnumerable<ClienteModel> Get();
    }
}
