using CRM_API.Model;
using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class SaldoServices : ISaldoServices
    {
        IUnidadTrabajo Unidad;

        public SaldoServices(IUnidadTrabajo unidad)
        {
            this.Unidad = unidad;
        }

        SaldoModel Convertir(Saldo saldo)
        {
            return new SaldoModel
            {
                IdSaldo = saldo.IdSaldo,
                IdCliente = saldo.IdCliente,
                MontoSaldo = saldo.MontoSaldo,
                IdMoneda = saldo.IdMoneda,
            };
        }

        Saldo Convertir(SaldoModel saldo)
        {
            return new Saldo
            {
                IdSaldo = saldo.IdSaldo,
                IdCliente = saldo.IdCliente,
                MontoSaldo = saldo.MontoSaldo,
                IdMoneda = saldo.IdMoneda,
            };
        }

        public bool Add(SaldoModel saldo)
        {
            try
            {
                Unidad.SaldoDAL.Add(Convertir(saldo));
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var saldo = new Saldo { IdSaldo = id };
            Unidad.SaldoDAL.Remove(saldo);
            return Unidad.Complete();
        }

        public List<SaldoModel> GetSaldo()
        {
            var saldo = Unidad.SaldoDAL.GetAll();

            List<SaldoModel> saldoModels = new List<SaldoModel>();

            foreach (var saldos in saldo)
            {
                saldoModels.Add(Convertir(saldos));
            }

            return saldoModels;
        }

        public SaldoModel GetById(int id)
        {
            return Convertir(Unidad.SaldoDAL.GetById(id));
        }

        public bool Update(SaldoModel saldo)
        {
            Unidad.SaldoDAL.Update(Convertir(saldo));
            return Unidad.Complete();
        }
    }
}
