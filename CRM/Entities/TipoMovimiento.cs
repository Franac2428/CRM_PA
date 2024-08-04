using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class TipoMovimiento
{
    public int IdTipoMovimiento { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
