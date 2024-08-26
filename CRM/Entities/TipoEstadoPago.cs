using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class TipoEstadoPago
{
    public int IdEstadoPago { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
