using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class ClienteSvc : IClienteSvc
    {
        private IUnidadTrabajo _ut;

        private IClienteDAL _DAL;

        public ClienteSvc(IUnidadTrabajo ut)
        {
            this._ut = ut;
        }


        #region [Conversión de entidades]
        private Cliente Convert(ClienteModel model)
        {
            Cliente entity = new Cliente
            {
                IdCliente = model.IdCliente,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Telefono = model.Telefono,
                Celular = model.Celular,
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Identificacion = model.Identificacion,
                Eliminado = model.Eliminado
            };

            return entity;
        }

        private ClienteModel Convert(Cliente model)
        {
            ClienteModel entity = new ClienteModel
            {
                IdCliente = model.IdCliente,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Telefono = model.Telefono,
                Celular = model.Celular,
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Identificacion = model.Identificacion,
                Eliminado = model.Eliminado
            };

            return entity;
        }


        #endregion


        public bool Add(ClienteModel model)
        {
            return _ut.ClienteDAL.Add(Convert(model));
        }

        public ClienteModel GetById(int id)
        {
            return Convert(_ut.ClienteDAL.GetById(id));
        }

        public IEnumerable<ClienteModel> Get()
        {

            var lista = _ut.ClienteDAL.GetAll();
            List<ClienteModel> c = new List<ClienteModel>();
            foreach (var item in lista)
            {
                c.Add(Convert(item));
            }

            return c;
        }

        public bool Remove(ClienteModel category)
        {
            return _ut.ClienteDAL.Remove(Convert(category));
        }

        public bool Update(ClienteModel category)
        {
            return _ut.ClienteDAL.Update(Convert(category));
        }
    }
}
