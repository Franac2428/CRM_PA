using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class TipoMoneda
{
    public int IdMoneda { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Saldo> Saldos { get; set; } = new List<Saldo>();

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
