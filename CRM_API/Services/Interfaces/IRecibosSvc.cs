using CRM_API.Models;
using AM = CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface IRecibosSvc
    {
        AM.CRMResponse GetPagosRecibos();

        AM.CRMResponse CancelarPago(int IdPago);
    }
}
