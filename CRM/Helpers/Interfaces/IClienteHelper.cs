using CRM.ViewModels;
using Entities.Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IClienteHelper
    {
        List<ClienteViewModel> GetClientes();

        List<TipoIdentificacion> GetTiposIdentificacion();

        ClienteViewModel AddCliente(ClienteViewModel cliente);

        ClienteViewModel GetClienteById(int id);

        ClienteViewModel UpdateCliente(ClienteViewModel cliente);

        //ClienteViewModel DeleteCliente(int id);


    }
}
