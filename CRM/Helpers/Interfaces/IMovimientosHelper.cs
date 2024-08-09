using CRM.ViewModels;
using Entities.Entities;

namespace CRM.Helpers.Interfaces
{
    public interface IMovimientosHelper
    {
        List<MovimientosViewModel> GetMovimientos();

        List<TipoEstadoMovimiento> GetTipoEstado();

        MovimientosViewModel AddSalEnt(MovimientosViewModel movimientos);

        MovimientosViewModel GetMovimientoByID(int id);

        MovimientosViewModel UpdateMovimiento(MovimientosViewModel movimientos);

    }
}
