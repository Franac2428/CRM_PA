using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface IMovimientoServices
    {
        IEnumerable<MovimientoModel> GetMovimiento();
        bool Add(MovimientoModel movimiento);
        bool Update(MovimientoModel movimiento);
        bool Delete(MovimientoModel movimiento);
        MovimientoModel GetById(int id);
    }
}
