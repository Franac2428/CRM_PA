using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class TipoEstadoMovimiento
{
    public int IdEstadoMovimiento { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
