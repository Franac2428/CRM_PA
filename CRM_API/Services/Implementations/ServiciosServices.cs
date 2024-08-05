using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;
using Microsoft.Build.Evaluation;

namespace CRM_API.Services.Implementations
{
    public class ServiciosServices : IServiciosServicios
    {
        private IUnidadTrabajo unidad;

        private IServiciosServicios servicios;

        public ServiciosServices(IUnidadTrabajo unidad)
        {
            this.unidad = unidad;
        }

        private Servicios Convert(ServiciosModel servicio)
        {
            Servicios entity = new Servicios
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaCreacion = servicio.FechaCreacion,
                IdUsuarioCreacion = servicio.IdUsuarioCreacion,
                FechaModificacion = servicio.FechaModificacion,
                IdUsuarioModificacion = servicio.IdUsuarioModificacion,
                IdMoneda = servicio.IdMoneda,
                Eliminado = servicio.Eliminado
            };

            return entity;
        }

        private ServiciosModel Convert(Servicios servicio)
        {
            ServiciosModel entity = new ServiciosModel
            {
                IdServicio = servicio.IdServicio,
                Nombre = servicio.Nombre,
                Monto = servicio.Monto,
                FechaCreacion = servicio.FechaCreacion,
                IdUsuarioCreacion = servicio.IdUsuarioCreacion,
                FechaModificacion = servicio.FechaModificacion,
                IdUsuarioModificacion = servicio.IdUsuarioModificacion,
                IdMoneda = servicio.IdMoneda,
                Eliminado = servicio.Eliminado
            };

            return entity;
        }


        public bool Add(ServiciosModel servicios)
        {
            return unidad.ServiciosDAL.Add(Convert(servicios));
        }

        public IEnumerable<ServiciosModel> Get()
        {
            var lista = unidad.ServiciosDAL.GetAll();
            List<ServiciosModel> servicios = new List<ServiciosModel>();
            foreach (var item in lista)
            {
                servicios.Add(Convert(item));
            }

            return servicios;
        }

        public ServiciosModel GetById(int id)
        {
            return Convert(unidad.ServiciosDAL.GetById(id));
        }

        public bool Remove(ServiciosModel servicios)
        {
            return unidad.ServiciosDAL.Remove(Convert(servicios));
        }

        public bool Update(ServiciosModel servicios)
        {
            return unidad.ServiciosDAL.Update(Convert(servicios));
        }
    }
}
