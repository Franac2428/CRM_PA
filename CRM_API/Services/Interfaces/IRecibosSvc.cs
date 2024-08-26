using AM = CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface IRecibosSvc
    {
        AM.CRMResponse GetPagosRecibos();
    }
}
