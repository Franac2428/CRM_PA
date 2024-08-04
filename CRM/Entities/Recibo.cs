using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class Recibo
{
    public int IdRecibo { get; set; }

    public int? IdCliente { get; set; }

    public decimal? MontoTotal { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? IdUsuarioCreacion { get; set; }

    public bool? Anulado { get; set; }

    public bool? AnuladoParcial { get; set; }

    public virtual ICollection<DetallesRecibo> DetallesRecibos { get; set; } = new List<DetallesRecibo>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
