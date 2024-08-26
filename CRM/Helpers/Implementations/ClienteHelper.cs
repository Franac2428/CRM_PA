using System.Collections.Generic;
using CRM.APIModels;
using CRM.ViewModels;
using Entities.Entities;
using Newtonsoft.Json; 

namespace CRM.Helpers.Interfaces
{
    public class ClienteHelper : IClienteHelper
    {
        IServiceRepository ServiceRepository;

        public ClienteHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }
        
        public List<ClienteViewModel> GetClientes()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/cliente");
            List<ClienteViewModel> listado = new List<ClienteViewModel>();
            List<ClienteModel> result = new List<ClienteModel>();

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<ClienteModel>>(content);
            }

            foreach(var item in result)
            {
                listado.Add(ConvertirModel(item));
            }

            return listado;


        }

        public List<TipoIdentificacion> GetTiposIdentificacion()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/tipoIdentificacion");
            List<TipoIdentificacion> result = new List<TipoIdentificacion>();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<TipoIdentificacion>>(content);
                return result;
            }
            else
            {
                return new List<TipoIdentificacion>();
            }
            


        }

        public ClienteViewModel AddCliente(ClienteViewModel cliente)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/cliente", ConvertirModel(cliente));

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ClienteViewModel();
        }

        public ClienteViewModel GetClienteById(int id)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/cliente/{id}");
            ClienteModel result = new ClienteModel();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ClienteModel>(content);
                return ConvertirModel(result);
            }
            else
            {
                return new ClienteViewModel();
            }

        }

        public ClienteViewModel UpdateCliente(ClienteViewModel cliente)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse($"api/cliente/{cliente.IdCliente}", ConvertirModel(cliente));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ClienteViewModel();
        }

        public List<ServiciosViewModel> GetServicios()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/servicios");
            List<ServiciosViewModel> listado = new List<ServiciosViewModel>();
            List<ServiciosModel> result = new List<ServiciosModel>();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<ServiciosModel>>(content);
            }

            foreach (var item in result)
            {
                listado.Add(ConvertirServiciosModel(item));
            }

            return listado;


        }



        #region [CONVERTIR MODELS]
        public ClienteViewModel ConvertirModel(ClienteModel model)
        {
            return new ClienteViewModel
            {
                IdCliente = model.IdCliente,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Telefono = model.Telefono,
                Celular = model.Celular,
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Identificacion = model.Identificacion,
                Eliminado = model.Eliminado,
                IdServicio = model.IdServicio,
                IdTipoPlan = model.IdTipoPlan,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                IdUsuarioModificacion = model.IdUsuarioModificacion,
                FechaCreacion = model.FechaCreacion,
                FechaModificacion = model.FechaModificacion
            };
        }

        public ClienteModel ConvertirModel(ClienteViewModel model)
        {
            return new ClienteModel
            {
                IdCliente = model.IdCliente,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Telefono = model.Telefono,
                Celular = model.Celular,
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Identificacion = model.Identificacion,
                Eliminado = model.Eliminado,
                IdServicio = model.IdServicio,
                IdTipoPlan = model.IdTipoPlan,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                IdUsuarioModificacion = model.IdUsuarioModificacion,
                FechaCreacion = model.FechaCreacion,
                FechaModificacion = model.FechaModificacion
            };
        }

        public ServiciosViewModel ConvertirServiciosModel(ServiciosModel model)
        {
            return new ServiciosViewModel
            {
                IdServicio = model.IdServicio,
                Nombre = model.Nombre,
                Monto = model.Monto,
                IdMoneda = model.IdMoneda,
                Eliminado = model.Eliminado
            };
        }


        public ServiciosModel ConvertirServiciosModel(ServiciosViewModel model)
        {
            return new ServiciosModel
            {
                IdServicio = model.IdServicio,
                Nombre = model.Nombre,
                Monto = model.Monto,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                IdUsuarioModificacion = model.IdUsuarioModificacion,
                FechaCreacion = model.FechaCreacion,
                FechaModificacion = model.FechaModificacion,
                IdMoneda = model.IdMoneda,
                Eliminado = model.Eliminado
            };
        }


        #endregion

    }
}
