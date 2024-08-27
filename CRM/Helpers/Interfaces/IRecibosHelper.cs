using CRM.APIModels;
using CRM.ViewModels;
using E = Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IRecibosHelper
    {
        CRMResponse GetPagosRecibos();
        CRMResponse CancelarPago(int idPago);
    }
}
