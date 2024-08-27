using CRM.ViewModels;
using Entities.Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IInfoEmpresaHelper
    {
        List<InfoEmpresaViewModel> GetEmpresas();

        List<TipoIdentificacion> GetTiposIdentificacion();

        InfoEmpresaViewModel AddEmpresa(InfoEmpresaViewModel empresa);

        InfoEmpresaViewModel GetEmpresaById(int id);

        InfoEmpresaViewModel UpdateEmpresa(InfoEmpresaViewModel empresa);

        // Otros métodos
        List<ServiciosViewModel> GetServicios();
    }
}
