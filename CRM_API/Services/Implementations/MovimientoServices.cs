using CRM_API.Model;
using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class MovimientoServices : IMovimientoServices
    {
        IUnidadTrabajo Unidad;

        public MovimientoServices(IUnidadTrabajo unidad)
        {
            this.Unidad = unidad;
        }

        MovimientoModel Convertir(Movimiento movimiento)
        {
            return new MovimientoModel
            {
                IdMovimiento = movimiento.IdMovimiento,
                IdTipoMovimiento = movimiento.IdTipoMovimiento,
                IdEstadoMovimiento = movimiento.IdEstadoMovimiento,
                Monto = movimiento.Monto,
                FechaCreacion = movimiento.FechaCreacion,
                IdUsuarioCreacion = movimiento.IdUsuarioCreacion,
                FechaModificacion = movimiento.FechaModificacion,
                IdUsuarioModificacion = movimiento.IdUsuarioModificacion,
                Comentario = movimiento.Comentario,
                Imagen = movimiento.Imagen,
            };
        }

        Movimiento Convertir(MovimientoModel movimiento)
        {
            return new Movimiento
            {
                IdMovimiento = movimiento.IdMovimiento,
                IdTipoMovimiento = movimiento.IdTipoMovimiento,
                IdEstadoMovimiento = movimiento.IdEstadoMovimiento,
                Monto = movimiento.Monto,
                FechaCreacion = movimiento.FechaCreacion,
                IdUsuarioCreacion = movimiento.IdUsuarioCreacion,
                FechaModificacion = movimiento.FechaModificacion,
                IdUsuarioModificacion = movimiento.IdUsuarioModificacion,
                Comentario = movimiento.Comentario,
                Imagen = movimiento.Imagen,
            };
        }

        public bool Add(MovimientoModel movimiento)
        {
            try
            {
                Unidad.MovimientoDAL.Add(Convertir(movimiento));
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var movimiento = new Movimiento { IdMovimiento = id };
            Unidad.MovimientoDAL.Remove(movimiento);
            return Unidad.Complete();
        }

        public List<MovimientoModel> GetMovimiento()
        {
            var movimiento = Unidad.MovimientoDAL.GetAll();

            List<MovimientoModel> movimientoModels = new List<MovimientoModel>();

            foreach (var movimientos in movimiento)
            {
                movimientoModels.Add(Convertir(movimientos));
            }

            return movimientoModels;
        }

        public MovimientoModel GetById(int id)
        {
            return Convertir(Unidad.MovimientoDAL.GetById(id));
        }

        public bool Update(MovimientoModel movimiento)
        {
            Unidad.MovimientoDAL.Update(Convertir(movimiento));
            return Unidad.Complete();
        }
    }
}
