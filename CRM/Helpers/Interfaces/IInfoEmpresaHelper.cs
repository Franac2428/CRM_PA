using CRM.APIModels;
using CRM.ViewModels;
using Entities.Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IInfoEmpresaHelper
    {
        CRMResponse Add(InfoEmpresaViewModel cliente);

        CRMResponse Get(int id);

        CRMResponse Update(InfoEmpresaViewModel cliente);

    }
}
