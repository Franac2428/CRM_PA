using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public int? IdTipoIdentificacion { get; set; }

    public string? Identificacion { get; set; }

    public bool? Eliminado { get; set; }

    public virtual TipoIdentificacion? IdTipoIdentificacionNavigation { get; set; }

    public virtual ICollection<PagosGenerado> PagosGenerados { get; set; } = new List<PagosGenerado>();

    public virtual ICollection<Recibo> Recibos { get; set; } = new List<Recibo>();

    public virtual ICollection<Saldo> Saldos { get; set; } = new List<Saldo>();
}
