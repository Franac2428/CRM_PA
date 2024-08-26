using AM = CRM_API.Models;
using Entities.Entities;
using E = Entities;
using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface IPagoSvc
    {
        bool Add(AM.PagoModel model);
        bool Remove(AM.PagoModel model);
        bool Update(AM.PagoModel model);
        AM.VerPagoModel GetPagoById(int IdPago);
        IEnumerable<AM.PagoModel> Get();
        IEnumerable<AM.ListaPagosModel> GetListaPagos(E.FiltrosReportes model);
        CRMResponse GenerarPagos(E.FiltrosReportes model);
        CRMResponse AgregarEditarPago(E.RegistrarPagoModel model);
    }
}
