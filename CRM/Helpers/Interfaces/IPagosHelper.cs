using CRM.APIModels;
using CRM.ViewModels;
using E = Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IPagosHelper
    {
        List<ListaPagosViewModel> GetListaPagos(E.FiltrosReportes model);

        VerPagoViewModel GetPagoById(int IdPago);

        CRMResponse AgregarEditarPago(RegistrarPagoModel model);
        //Otros métodos necesarios
        List<ClienteViewModel> GetClientes();
        List<ServiciosViewModel> GetServicios();
        CRMResponse GenerarPagos(FiltrosReportes model);

    }
}
