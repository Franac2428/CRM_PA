using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface ITipoIdentificacionSvc
    {
        bool Add(TipoIdentificacionModel category);
        bool Remove(TipoIdentificacionModel category);
        bool Update(TipoIdentificacionModel category);
        TipoIdentificacionModel GetById(int id);
        IEnumerable<TipoIdentificacionModel> Get();
    }
}
