using CRM_API.Models;

namespace CRM_API.Services.Interfaces
{
    public interface ISaldoServices
    {
        List<SaldoModel> GetSaldo();
        bool Add(SaldoModel saldo);
        bool Update(SaldoModel saldo);
        bool Delete(int id);
        SaldoModel GetById(int id);
    }
}
