using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface ITipoEstadoPagoServices
    {

        bool Add(TipoEstadoPagoModel tipoEstado);
        bool Remove(TipoEstadoPagoModel tipoEstado);

        bool Update(TipoEstadoPagoModel tipoEstado);

        TipoEstadoPagoModel GetById(int id);

        IEnumerable<TipoEstadoPagoModel> Get();

    }
}
