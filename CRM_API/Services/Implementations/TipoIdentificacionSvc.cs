using CRM_API.Models;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class TipoIdentificacionSvc : ITipoIdentificacionSvc
    {
        private IUnidadTrabajo _ut;

        private ITipoIdentificacionDAL _DAL;

        public TipoIdentificacionSvc(IUnidadTrabajo ut)
        {
            this._ut = ut;
        }


        #region [Conversión de entidades]
        private TipoIdentificacion Convert(TipoIdentificacionModel model)
        {
            TipoIdentificacion entity = new TipoIdentificacion
            {
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Nombre = model.Nombre,

            };

            return entity;
        }

        private TipoIdentificacionModel Convert(TipoIdentificacion model)
        {
            TipoIdentificacionModel entity = new TipoIdentificacionModel
            {
                IdTipoIdentificacion = model.IdTipoIdentificacion,
                Nombre = model.Nombre,

            };

            return entity;
        }

        #endregion


        public bool Add(TipoIdentificacionModel model)
        {
            return _ut.TipoIdentificacionDAL.Add(Convert(model));
        }

        public TipoIdentificacionModel GetById(int id)
        {
            return Convert(_ut.TipoIdentificacionDAL.GetById(id));
        }

        public IEnumerable<TipoIdentificacionModel> Get()
        {

            var lista = _ut.TipoIdentificacionDAL.GetAll();
            List<TipoIdentificacionModel> c = new List<TipoIdentificacionModel>();
            foreach (var item in lista)
            {
                c.Add(Convert(item));
            }

            return c;
        }

        public bool Remove(TipoIdentificacionModel category)
        {
            return _ut.TipoIdentificacionDAL.Remove(Convert(category));
        }

        public bool Update(TipoIdentificacionModel category)
        {
            return _ut.TipoIdentificacionDAL.Update(Convert(category));
        }
    }
}
