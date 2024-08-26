using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using Newtonsoft.Json;

namespace CRM.Helpers.Implementations
{
    public class GraficosHelper : IGraficosHelper
    {
        IServiceRepository ServiceRepository;

        public GraficosHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }
        public GraficosViewModel GetGraficos()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/graficos");
            GraficosViewModel result = new GraficosViewModel();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<GraficosViewModel>(content);
            }

            return result;


        }
    }
}
