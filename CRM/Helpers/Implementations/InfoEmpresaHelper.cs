using CRM.APIModels;
using CRM.Helpers.Implementations;
using CRM.ViewModels;
using CRM.Helpers.Interfaces;
using E = Entities.Entities;
using Newtonsoft.Json;
using CRM.Entities;

namespace CRM.Helpers.Implementations

{
    public class InfoEmpresaHelper : IInfoEmpresaHelper
    {
        IServiceRepository ServiceRepository;

        public InfoEmpresaHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }

        public CRMResponse Add(InfoEmpresaViewModel model)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/infoempresa", ConvertirModel(model));

            CRMResponse result = new CRMResponse();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }

            return new CRMResponse()
            {
                Codigo = 400,
                Mensaje = "",
                Status = "Success",
                Data = null
            };
        }

        public CRMResponse Get(int id)
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/infoempresa");

            CRMResponse result = new CRMResponse();

            if (response != null)
            {
                try
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var r = JsonConvert.DeserializeObject<List<InfoEmpresaViewModel>>(content);
                    var data = r.FirstOrDefault();
                    
                    return new CRMResponse()
                    {
                        Codigo = 200,
                        Mensaje = "",
                        Status = "Success",
                        Data = data
                    };
                }
                catch (Exception ex) {

                    return new CRMResponse()
                    {
                        Codigo = 400,
                        Mensaje = "",
                        Status = "Failed",
                        Data = ex.Message
                    };
                }
                
            }

            return new CRMResponse()
            {
                Codigo = 400,
                Mensaje = "",
                Status = "Failed",
                Data = null
            };

        }

        public CRMResponse Update(InfoEmpresaViewModel model)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse("api/infoempresa", ConvertirModel(model));

            CRMResponse result = new CRMResponse();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }

            return new CRMResponse()
            {
                Codigo = 400,
                Mensaje = "",
                Status = "Success",
                Data = null
            };
        }

        public InfoEmpresaViewModel ConvertirModel(InfoEmpresaModel model)
        {
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

        public InfoEmpresaModel ConvertirModel(InfoEmpresaViewModel model)
        {
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

    }
}
