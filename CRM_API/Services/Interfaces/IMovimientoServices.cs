using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface IMovimientoServices
    {
        List<MovimientoModel> GetMovimiento();
        bool Add(MovimientoModel movimiento);
        bool Update(MovimientoModel movimiento);
        bool Delete(int id);
        MovimientoModel GetById(int id);
    }
}
