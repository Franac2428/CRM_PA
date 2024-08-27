using CRM.APIModels;
using CRM.ViewModels;
using Entities.Entities;

namespace CRM.Helpers.Interfaces
{
    public interface ILoginHelper
    {
        CRMResponse OnLogin(LoginModel model);
        CRMResponse OnRegister(RegisterModel model);
    }
}
