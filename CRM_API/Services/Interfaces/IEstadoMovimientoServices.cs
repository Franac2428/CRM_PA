using CRM_API.Model;
using Entities.Entities;

namespace CRM_API.Services.Interfaces
{
    public interface IEstadoMovimientoServices
    {

        List<EstadoMovimientoModel> GetEstadoMovimientos();
        bool Add(EstadoMovimientoModel tipoEstadoMovimiento);
        bool Update(EstadoMovimientoModel tipoEstadoMovimiento);
        bool Delete(int id);
        EstadoMovimientoModel GetById(int id);

    }
}
