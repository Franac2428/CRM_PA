using CRM.APIModels;
using CRM.Helpers.Interfaces;
using CRM.ViewModels;
using E = Entities;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace CRM.Helpers.Implementations
{
    public class RecibosHelper : IRecibosHelper
    {
        IServiceRepository ServiceRepository;

        public RecibosHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }

        public CRMResponse GetPagosRecibos()
        {
            HttpResponseMessage response = ServiceRepository.GetResponse("api/recibos");
            CRMResponse result = new CRMResponse();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<CRMResponse>(content);
            }


            return result;


        }

        public CRMResponse CancelarPago(int idPago)
        {
            HttpResponseMessage response = ServiceRepository.PutResponse($"api/recibos/{idPago}",null);
            CRMResponse result = new CRMResponse();

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<CRMResponse>(content);
            }


            return result;


        }








    }
}
