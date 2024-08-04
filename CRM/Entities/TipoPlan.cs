using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class TipoPlan
{
    public int IdTipoPlan { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
