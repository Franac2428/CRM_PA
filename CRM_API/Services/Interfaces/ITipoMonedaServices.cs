using CRM_API.Model;
using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface ITipoMonedaServices
    {
        List<TipoMonedaModel> GetTipoMoneda();
        bool Add(TipoMonedaModel tipoMoneda);
        bool Update(TipoMonedaModel tipoMoneda);
        bool Delete(int id);
        TipoMonedaModel GetById(int id);
    }
}
