using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class TipoEstadoPagoServices : ITipoEstadoPagoServices
    {
        private IUnidadTrabajo unidad;

        private ITipoEstadoPagoServices services;

        public TipoEstadoPagoServices(IUnidadTrabajo unidad)
        {
            this.unidad = unidad;
        }

        private TipoEstadoPago Convert(TipoEstadoPagoModel tipoEstado)
        {
            TipoEstadoPago entity = new TipoEstadoPago
            {
                IdEstadoPago = tipoEstado.IdEstadoPago,
                Nombre = tipoEstado.Nombre
            };

            return entity;
        }

        private TipoEstadoPagoModel Convert(TipoEstadoPago tipoEstado)
        {
            TipoEstadoPagoModel entity = new TipoEstadoPagoModel
            {
                IdEstadoPago = tipoEstado.IdEstadoPago,
                Nombre = tipoEstado.Nombre
            };

            return entity;
        }
        public bool Add(TipoEstadoPagoModel tipoEstado)
        {
            return unidad.TipoEstadoPagoDAL.Add(Convert(tipoEstado));
        }

        public IEnumerable<TipoEstadoPagoModel> Get()
        {
            var lista = unidad.TipoEstadoPagoDAL.GetAll();
            List<TipoEstadoPagoModel> tipoEstados = new List<TipoEstadoPagoModel>();
            foreach (var item in lista)
            {
                tipoEstados.Add(Convert(item));
            }

            return tipoEstados;
        }

        public TipoEstadoPagoModel GetById(int id)
        {
            return Convert(unidad.TipoEstadoPagoDAL.GetById(id));
        }

        public bool Remove(TipoEstadoPagoModel tipoEstado)
        {
            return unidad.TipoEstadoPagoDAL.Remove(Convert(tipoEstado));
        }

        public bool Update(TipoEstadoPagoModel tipoEstado)
        {
            return unidad.TipoEstadoPagoDAL.Update(Convert(tipoEstado));
        }
    }
}
