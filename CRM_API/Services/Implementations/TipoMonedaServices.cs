using CRM_API.Model;
using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class TipoMonedaServices : ITipoMonedaServices
    {
        IUnidadTrabajo Unidad;

        public TipoMonedaServices(IUnidadTrabajo unidad)
        {
            this.Unidad = unidad;
        }

        TipoMonedaModel Convertir(TipoMoneda tipoMoneda)
        {
            return new TipoMonedaModel
            {
                IdMoneda = tipoMoneda.IdMoneda,
                Nombre = tipoMoneda.Nombre,
            };
        }

        TipoMoneda Convertir(TipoMonedaModel tipoMoneda)
        {
            return new TipoMoneda
            {
                IdMoneda = tipoMoneda.IdMoneda,
                Nombre = tipoMoneda.Nombre,
            };
        }

        public bool Add(TipoMonedaModel tipoMoneda)
        {
            try
            {
                Unidad.TipoMonedaDAL.Add(Convertir(tipoMoneda));
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var tipoMoneda = new TipoMoneda { IdMoneda = id };
            Unidad.TipoMonedaDAL.Remove(tipoMoneda);
            return Unidad.Complete();
        }

        public List<TipoMonedaModel> GetTipoMoneda()
        {
            var tipoMoneda = Unidad.TipoMonedaDAL.GetAll();

            List<TipoMonedaModel> tipoMonedaModels = new List<TipoMonedaModel>();

            foreach (var tipoMonedas in tipoMoneda)
            {
                tipoMonedaModels.Add(Convertir(tipoMonedas));
            }

            return tipoMonedaModels;
        }

        public TipoMonedaModel GetById(int id)
        {
            return Convertir(Unidad.TipoMonedaDAL.GetById(id));
        }

        public bool Update(TipoMonedaModel tipoMoneda)
        {
            Unidad.TipoMonedaDAL.Update(Convertir(tipoMoneda));
            return Unidad.Complete();
        }
    }
}
