using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public int? IdTipoMovimiento { get; set; }

    public int? IdEstadoMovimiento { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? IdUsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? IdUsuarioModificacion { get; set; }

    public string? Comentario { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual TipoEstadoMovimiento? IdEstadoMovimientoNavigation { get; set; }

    public virtual TipoMovimiento? IdTipoMovimientoNavigation { get; set; }
}
