using CRM.ViewModels;
using Entities.Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IServiciosHelper
    {
        List<ServiciosViewModel> GetServicios();

        List<TipoIdentificacion> GetTiposMoneda();

        ServiciosViewModel AddServicio(ServiciosViewModel Servicio);

        ServiciosViewModel GetServicioById(int id);

        ServiciosViewModel UpdateServicio(ServiciosViewModel Servicio);

        //ServicioViewModel DeleteServicio(int id);


    }
}
