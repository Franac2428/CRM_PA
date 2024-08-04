using CRM.ViewModels;
using Entities.Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IServicioHelper
    {
        List<ServicioViewModel> GetServicios();

        List<TipoIdentificacion> GetTiposMoneda();

        ServicioViewModel AddServicio(ServicioViewModel Servicio);

        ServicioViewModel GetServicioById(int id);

        ServicioViewModel UpdateServicio(ServicioViewModel Servicio);

        //ServicioViewModel DeleteServicio(int id);


    }
}
