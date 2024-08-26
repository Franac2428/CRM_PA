using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Servicios
{
    public int IdServicio { get; set; }

    public string? Nombre { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? IdUsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? IdUsuarioModificacion { get; set; }

    public int? IdMoneda { get; set; }

    public bool? Eliminado { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual TipoMoneda? IdMonedaNavigation { get; set; }

    public virtual AspNetUser? IdUsuarioCreacionNavigation { get; set; }

    public virtual AspNetUser? IdUsuarioModificacionNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
