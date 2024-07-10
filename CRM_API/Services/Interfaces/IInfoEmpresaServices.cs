using CRM_API.Model;

namespace CRM_API.Services.Interfaces
{
    public interface IInfoEmpresaServices
    {

        List<InfoEmpresaModel> GetInfoEmpresas();
        bool Add(InfoEmpresaModel infoEmpresa);
        bool Update(InfoEmpresaModel infoEmpresa);
        bool Delete(int id);
        InfoEmpresaModel GetById(int id);

    }
}
