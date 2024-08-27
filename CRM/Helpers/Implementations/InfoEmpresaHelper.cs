using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Entities.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace CRM.Helpers.Implementations
{
    public class InfoEmpresaHelper : IInfoEmpresaHelper
    {
        IServiceRepository ServiceRepository;

        public InfoEmpresaHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }

        public List<InfoEmpresaViewModel> GetEmpresas()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/infoempresa");
            List<InfoEmpresaViewModel> listado = new List<InfoEmpresaViewModel>();

            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<InfoEmpresaModel>>(content);

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        listado.Add(ConvertirModel(item));
                    }
                }
            }

            return listado;
        }

        public List<TipoIdentificacion> GetTiposIdentificacion()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/tipoIdentificacion");
            List<TipoIdentificacion> result = new List<TipoIdentificacion>();

            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<TipoIdentificacion>>(content);
            }

            return result;
        }

        public InfoEmpresaViewModel AddEmpresa(InfoEmpresaViewModel empresa)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/infoempresa", ConvertirModel(empresa));

            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<InfoEmpresaModel>(content);
                return result != null ? ConvertirModel(result) : new InfoEmpresaViewModel();
            }

            return new InfoEmpresaViewModel();
        }

        public InfoEmpresaViewModel GetEmpresaById(int id)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse($"api/infoempresa/{id}");

            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<InfoEmpresaModel>(content);
                return result != null ? ConvertirModel(result) : new InfoEmpresaViewModel();
            }

            return new InfoEmpresaViewModel();
        }

        public InfoEmpresaViewModel UpdateEmpresa(InfoEmpresaViewModel empresa)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse($"api/InfoEmpresa/{empresa.IdInfoEmpresa}", ConvertirModel(empresa));

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }

            return new InfoEmpresaViewModel();
        }

        // Implementación del método GetServicios
        public List<ServiciosViewModel> GetServicios()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/servicios");
            List<ServiciosViewModel> listado = new List<ServiciosViewModel>();

            if (response != null && response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<ServiciosModel>>(content);

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        listado.Add(ConvertirServiciosModel(item));
                    }
                }
            }

            return listado;
        }

        #region [CONVERTIR MODELS]
        private InfoEmpresaViewModel ConvertirModel(InfoEmpresaModel model)
        {
            if (model == null) return new InfoEmpresaViewModel();

            return new InfoEmpresaViewModel
            {
                IdInfoEmpresa = model.IdInfoEmpresa,
                Identificacion = model.Identificacion,
                Actividad = model.Actividad,
                Correo = model.Correo,
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Nombre = model.Nombre,
                Telefono = model.Telefono
            };
        }

        private InfoEmpresaModel ConvertirModel(InfoEmpresaViewModel model)
        {
            if (model == null) return new InfoEmpresaModel();

            return new InfoEmpresaModel
            {
                IdInfoEmpresa = model.IdInfoEmpresa,
                Identificacion = model.Identificacion,
                Actividad = model.Actividad,
                Correo = model.Correo,
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Nombre = model.Nombre,
                Telefono = model.Telefono
            };
        }

        private ServiciosViewModel ConvertirServiciosModel(ServiciosModel model)
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

        private ServiciosModel ConvertirServiciosModel(ServiciosViewModel model)
        {
            return new ServiciosModel
            {
                IdServicio = model.IdServicio,
                Nombre = model.Nombre,
                Monto = model.Monto,
                IdMoneda = model.IdMoneda,
                Eliminado = model.Eliminado
            };
        }
        #endregion
    }
}
