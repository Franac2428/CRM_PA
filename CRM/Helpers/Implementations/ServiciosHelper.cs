using System.Collections.Generic;
using CRM.APIModels;
using CRM.ViewModels;
using Entities.Entities;
using Newtonsoft.Json; 

namespace CRM.Helpers.Interfaces
{
    public class ServiciosHelper : IServiciosHelper
    {
        IServiceRepository ServiceRepository;

        public ServiciosHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }
        
        public List<ServiciosViewModel> GetServicios()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/Servicio");
            List<ServiciosViewModel> listado = new List<ServiciosViewModel>();
            List<ServiciosModel> result = new List<ServiciosModel>();

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<ServiciosModel>>(content);
            }

            foreach(var item in result)
            {
                listado.Add(ConvertirModel(item));
            }

            return listado;


        }

        public List<TipoIdentificacion> GetTiposMoneda()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/IdMoneda");
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

        public ServiciosViewModel AddServicio(ServiciosViewModel Servicio)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/Servicio", ConvertirModel(Servicio));

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ServiciosViewModel();
        }

        public ServiciosViewModel GetServicioById(int id)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/Servicio/{id}");
            ServiciosModel result = new ServiciosModel();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ServiciosModel>(content);
                return ConvertirModel(result);
            }
            else
            {
                return new ServiciosViewModel();
            }

        }

        public ServiciosViewModel UpdateServicio(ServiciosViewModel Servicio)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse($"api/Servicio/{Servicio.IdServicio}", ConvertirModel(Servicio));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ServiciosViewModel();
        }


        #region [CONVERTIR MODELS]
        public ServiciosViewModel ConvertirModel(ServiciosModel model)
        {
            return new ServiciosViewModel
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
		

		public ServiciosModel ConvertirModel(ServiciosViewModel model)
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
