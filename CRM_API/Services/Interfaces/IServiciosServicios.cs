using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface IServiciosServicios
    {

        bool Add(ServiciosModel servicios);

        bool Remove(ServiciosModel servicios);

        bool Update(ServiciosModel servicios);

        ServiciosModel GetById(int id);

        IEnumerable<ServiciosModel> Get();

    }
}
