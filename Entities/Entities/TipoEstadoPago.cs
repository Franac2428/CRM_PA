using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class TipoEstadoPago
{
    public int IdEstadoPago { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<PagosGenerado> PagosGenerados { get; set; } = new List<PagosGenerado>();
}
