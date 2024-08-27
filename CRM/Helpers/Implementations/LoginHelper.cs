using System.Collections.Generic;
using CRM.APIModels;
using CRM.ViewModels;
using Entities.Entities;
using Newtonsoft.Json;

namespace CRM.Helpers.Interfaces
{
    public class LoginHelper : ILoginHelper
    {
        IServiceRepository ServiceRepository;

        public LoginHelper(IServiceRepository service)
        {
            this.ServiceRepository = service;
        }

        public CRMResponse OnLogin(LoginModel model)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/auth/login", model);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<CRMResponse>(content);

                return result;
            }
            else
            {
                return new CRMResponse();
            }
        }
        public CRMResponse OnRegister(RegisterModel model)
        {
            HttpResponseMessage response = ServiceRepository.PostResponse("api/auth/register", model);

            if (response != null)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<CRMResponse>(content);

                return result;
            }
            else
            {
                return new CRMResponse();
            }
        }
    }
}
