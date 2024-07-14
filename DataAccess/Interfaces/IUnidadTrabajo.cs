using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUnidadTrabajo : IDisposable
    {
        //Agregar los demás DAL referentes a los Entities
        ITipoIdentificacionDAL TipoIdentificacionDAL { get; }
        IClienteDAL ClienteDAL { get; }


        IEstadoMovimientoDAL EstadoMovimientoDAL { get; }

        IInfoEmpresaDAL InfoEmpresaDAL { get; }

        IServiciosDAL ServiciosDAL { get; }

        ITipoEstadoPagoDAL TipoEstadoPagoDAL { get; }

        bool Complete();
    }
}
