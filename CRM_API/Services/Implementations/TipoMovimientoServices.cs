using CRM_API.Model;
using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class TipoMovimientoServices : ITipoMovimientoServices
    {
        IUnidadTrabajo Unidad;

        public TipoMovimientoServices(IUnidadTrabajo unidad)
        {
            this.Unidad = unidad;
        }

        TipoMovimientoModel Convertir(TipoMovimiento tipoMovimiento)
        {
            return new TipoMovimientoModel
            {
                IdTipoMovimiento = tipoMovimiento.IdTipoMovimiento,
                Nombre = tipoMovimiento.Nombre,
            };
        }

        TipoMovimiento Convertir(TipoMovimientoModel tipoMovimiento)
        {
            return new TipoMovimiento
            {
                IdTipoMovimiento = tipoMovimiento.IdTipoMovimiento,
                Nombre = tipoMovimiento.Nombre,
            };
        }

        public bool Add(TipoMovimientoModel tipoMovimiento)
        {
            try
            {
                Unidad.TipoMovimientoDAL.Add(Convertir(tipoMovimiento));
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var tipoMovimiento = new TipoMovimiento { IdTipoMovimiento = id };
            Unidad.TipoMovimientoDAL.Remove(tipoMovimiento);
            return Unidad.Complete();
        }

        public List<TipoMovimientoModel> GetTipoMovimiento()
        {
            var tipoMovimiento = Unidad.TipoMovimientoDAL.GetAll();

            List<TipoMovimientoModel> tipoMovimientoModels = new List<TipoMovimientoModel>();

            foreach (var tipoMovimientos in tipoMovimiento)
            {
                tipoMovimientoModels.Add(Convertir(tipoMovimientos));
            }

            return tipoMovimientoModels;
        }

        public TipoMovimientoModel GetById(int id)
        {
            return Convertir(Unidad.TipoMovimientoDAL.GetById(id));
        }

        public bool Update(TipoMovimientoModel tipoMovimiento)
        {
            Unidad.TipoMovimientoDAL.Update(Convertir(tipoMovimiento));
            return Unidad.Complete();
        }
    }
}
