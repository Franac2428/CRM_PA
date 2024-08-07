using CRM_API.Model;
using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Implementations;
using DataAccess.Interfaces;
using Entities.Entities;
using System.ComponentModel;

namespace CRM_API.Services.Implementations
{
    public class MovimientoServices : IMovimientoServices
    {
        IUnidadTrabajo Unidad;

        private IMovimientoDAL _DAL;

        public MovimientoServices(IUnidadTrabajo unidad)
        {
            this.Unidad = unidad;
        }

        private MovimientoModel Convertir(Movimiento movimiento)
        {
            MovimientoModel entity = new MovimientoModel
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
                Imagen = movimiento.Imagen
            };
            return entity;
        }

        private Movimiento Convertir(MovimientoModel movimiento)
        {
            Movimiento entity = new Movimiento
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
                Imagen = movimiento.Imagen
            };
            return entity;
        }

        public bool Add(MovimientoModel movimiento)
        {
            return Unidad.MovimientoDAL.Add(Convertir(movimiento));
        }

        public bool Delete(MovimientoModel movimiento)
        {
            return Unidad.MovimientoDAL.Remove(Convertir(movimiento));

        }

        public IEnumerable<MovimientoModel> GetMovimiento()
        {
            var movimiento = Unidad.MovimientoDAL.GetAll();

            List<MovimientoModel> movimientoModels = new List<MovimientoModel>();

            foreach (var item in movimiento)
            {
                movimientoModels.Add(Convertir(item));
            }

            return movimientoModels;
        }

        public MovimientoModel GetById(int id)
        {
            return Convertir(Unidad.MovimientoDAL.GetById(id));
        }

        public bool Update(MovimientoModel movimiento)
        {
            return Unidad.MovimientoDAL.Update(Convertir(movimiento));

        }
    }
}
