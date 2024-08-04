using System.Collections.Generic;
using CRM.APIModels;
using CRM.ViewModels;
using Entities.Entities;
using Newtonsoft.Json; 

namespace CRM.Helpers.Interfaces
{
    public class ServicioHelper : IServicioHelper
    {
        IServiceRepository ServiceRepository;

        public ServicioHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }
        
        public List<ServicioViewModel> GetServicios()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/Servicio");
            List<ServicioViewModel> listado = new List<ServicioViewModel>();
            List<ServicioModel> result = new List<ServicioModel>();

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<ServicioModel>>(content);
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

        public ServicioViewModel AddServicio(ServicioViewModel Servicio)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/Servicio", ConvertirModel(Servicio));

            if(response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ServicioViewModel();
        }

        public ServicioViewModel GetServicioById(int id)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/Servicio/{id}");
            ServicioModel result = new ServicioModel();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<ServicioModel>(content);
                return ConvertirModel(result);
            }
            else
            {
                return new ServicioViewModel();
            }

        }

        public ServicioViewModel UpdateServicio(ServicioViewModel Servicio)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse($"api/Servicio/{Servicio.IdServicio}", ConvertirModel(Servicio));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return new ServicioViewModel();
        }


        #region [CONVERTIR MODELS]
        public ServicioViewModel ConvertirModel(ServicioModel model)
        {
            return new ServicioViewModel
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
		

		public ServicioModel ConvertirModel(ServicioViewModel model)
        {
            return new ServicioModel
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
