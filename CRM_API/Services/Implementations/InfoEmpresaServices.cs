using CRM_API.Model;
using CRM_API.Services.Interfaces;
using DataAccess.Interfaces;
using Entities.Entities;

namespace CRM_API.Services.Implementations
{
    public class InfoEmpresaServices : IInfoEmpresaServices
    {
        IUnidadTrabajo Unidad;

        public InfoEmpresaServices(IUnidadTrabajo Unidad)
        {
            this.Unidad = Unidad;
        }

        InfoEmpresaModel Convertir(InfoEmpresa infoEmpresa)
        {
            return new InfoEmpresaModel
            {
                IdInfoEmpresa = infoEmpresa.IdInfoEmpresa,
                Nombre = infoEmpresa.Nombre,
                Correo = infoEmpresa.Correo,
                Telefono = infoEmpresa.Telefono,
                Actividad = infoEmpresa.Actividad,
                IdTipoIdentificacion = infoEmpresa.IdTipoIdentificacion,
                Identificacion = infoEmpresa.Identificacion
            };
        }

        InfoEmpresa Convertir(InfoEmpresaModel infoEmpresa)
        {
            return new InfoEmpresa
            {
                IdInfoEmpresa = infoEmpresa.IdInfoEmpresa,
                Nombre = infoEmpresa.Nombre,
                Correo = infoEmpresa.Correo,
                Telefono = infoEmpresa.Telefono,
                Actividad = infoEmpresa.Actividad,
                IdTipoIdentificacion = infoEmpresa.IdTipoIdentificacion,
                Identificacion = infoEmpresa.Identificacion
            };
        }


        public bool Add(InfoEmpresaModel infoEmpresa)
        {
            try
            {
                Unidad.InfoEmpresaDAL.Add(Convertir(infoEmpresa));
                return Unidad.Complete();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            var infoempresa = new InfoEmpresa { IdInfoEmpresa = id };
            Unidad.InfoEmpresaDAL.Remove(infoempresa);
            return Unidad.Complete();
        }

        public InfoEmpresaModel GetById(int id)
        {
            return Convertir(Unidad.InfoEmpresaDAL.GetById(id));
        }

        public List<InfoEmpresaModel> GetInfoEmpresas()
        {
            var infoempresas = Unidad.InfoEmpresaDAL.GetAll();

            List<InfoEmpresaModel> infoEmpresasmodel = new List<InfoEmpresaModel>();

            foreach (var infoempresa in infoempresas)
            {
                infoEmpresasmodel.Add(Convertir(infoempresa));
            }

            return infoEmpresasmodel;
        }

        public bool Update(InfoEmpresaModel infoEmpresa)
        {
            Unidad.InfoEmpresaDAL.Update(Convertir(infoEmpresa));
            return Unidad.Complete();
        }
    }
}
