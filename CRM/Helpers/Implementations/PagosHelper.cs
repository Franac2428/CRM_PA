using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using E = Entities;
using Newtonsoft.Json;

namespace CRM.Helpers.Implementations
{
    public class PagosHelper : IPagosHelper
    {
        IServiceRepository ServiceRepository;

        public PagosHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }

        public List<ListaPagosViewModel> GetListaPagos(E.FiltrosReportes model)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/pago",model);
            List<ListaPagosViewModel> result = new List<ListaPagosViewModel>();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<ListaPagosViewModel>>(content);
            }

            return result;


        }
        
        public VerPagoViewModel GetPagoById(int IdPago)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/pago/{IdPago}");
            VerPagoViewModel result = new VerPagoViewModel();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<VerPagoViewModel>(content);
            }

            return result;
        }

        public List<ClienteViewModel> GetClientes()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/cliente");
            List<ClienteViewModel> listado = new List<ClienteViewModel>();
            List<ClienteModel> result = new List<ClienteModel>();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<ClienteModel>>(content);
            }

            foreach (var item in result)
            {
                listado.Add(ConvertirClienteModel(item));
            }

            return listado;


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

        public CRMResponse AgregarEditarPago(RegistrarPagoModel model)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse($"api/registrarpago/",model);
            CRMResponse result = new CRMResponse();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<CRMResponse>(content);
            }

            return result;
        }

        public CRMResponse GenerarPagos(FiltrosReportes model)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse($"api/generarpagos/", model);
            CRMResponse result = new CRMResponse();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<CRMResponse>(content);
            }

            return result;
        }


        #region [CONVERTIR MODELS]
        public ClienteViewModel ConvertirClienteModel(ClienteModel model)
        {
            return new ClienteViewModel
            {
                IdCliente = model.IdCliente,
                Nombre = model.Nombre,
                Eliminado = model.Eliminado,
                IdServicio = model.IdServicio,

            };
        }
        public ClienteModel ConvertirClienteModel(ClienteViewModel model)
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
