using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface ITipoMovimientoServices
    {
        List<TipoMovimientoModel> GetTipoMovimiento();
        bool Add(TipoMovimientoModel tipoMovimiento);
        bool Update(TipoMovimientoModel tipoMovimiento);
        bool Delete(int id);
        TipoMovimientoModel GetById(int id);
    }
}
