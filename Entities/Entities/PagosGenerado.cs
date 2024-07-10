using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class PagosGenerado
{
    public int IdPagoGenerado { get; set; }

    public int? IdCliente { get; set; }

    public decimal? MontoPago { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? IdUsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public DateOnly? MesPago { get; set; }

    public int? IdEstadoPago { get; set; }

    public int? IdServicio { get; set; }

    public bool? Eliminado { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual TipoEstadoPago? IdEstadoPagoNavigation { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }
}
