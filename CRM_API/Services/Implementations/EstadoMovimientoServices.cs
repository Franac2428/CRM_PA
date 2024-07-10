using CRM_API.Model;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class EstadoMovimientoServices : IEstadoMovimientoServices
    {
        IUnidadTrabajo Unidad;

        public EstadoMovimientoServices(IUnidadTrabajo unidad)
        {
            this.Unidad = unidad;
        }

        EstadoMovimientoModel Convertir(TipoEstadoMovimiento tipoEstadoMovimiento)
        {
            return new EstadoMovimientoModel
            {
                IdEstadoMovimiento = tipoEstadoMovimiento.IdEstadoMovimiento,
                Nombre = tipoEstadoMovimiento.Nombre
            };
        }

        TipoEstadoMovimiento Convertir(EstadoMovimientoModel tipoEstadoMovimiento)
        {
            return new TipoEstadoMovimiento
            {
                IdEstadoMovimiento = tipoEstadoMovimiento.IdEstadoMovimiento,
                Nombre = tipoEstadoMovimiento.Nombre
            };
        }

        public bool Add(EstadoMovimientoModel tipoEstadoMovimiento)
        {
            try
            {
                Unidad.EstadoMovimientoDAL.Add(Convertir(tipoEstadoMovimiento));
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var estadomovimiento = new TipoEstadoMovimiento { IdEstadoMovimiento = id };
            Unidad.EstadoMovimientoDAL.Remove(estadomovimiento);
            return Unidad.Complete();
        }

        public List<EstadoMovimientoModel> GetEstadoMovimientos()
        {
            var estado = Unidad.EstadoMovimientoDAL.GetAll();

            List<EstadoMovimientoModel> estadoMovimientoModels = new List<EstadoMovimientoModel>();

            foreach (var estadomovimiento in estado)
            {
                estadoMovimientoModels.Add(Convertir(estadomovimiento));
            }

            return estadoMovimientoModels;
        }

        public EstadoMovimientoModel GetById(int id)
        {
            return Convertir(Unidad.EstadoMovimientoDAL.GetById(id));
        }

        public bool Update(EstadoMovimientoModel tipoEstadoMovimiento)
        {
            Unidad.EstadoMovimientoDAL.Update(Convertir(tipoEstadoMovimiento));
            return Unidad.Complete();
        }
    }
}
