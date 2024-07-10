using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Nombre { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? IdUsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public int? IdMoneda { get; set; }

    public bool? Eliminado { get; set; }

    public virtual TipoMoneda? IdMonedaNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<PagosGenerado> PagosGenerados { get; set; } = new List<PagosGenerado>();
}
