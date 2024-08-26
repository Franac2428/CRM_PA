using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? IdCliente { get; set; }

    public decimal? MontoPago { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? IdUsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? IdUsuarioModificacion { get; set; }

    public DateOnly? MesPago { get; set; }

    public int? IdEstadoPago { get; set; }

    public int? IdServicio { get; set; }

    public string? Comentario { get; set; }

    public string? NumeroComprobannte { get; set; }

    public byte[]? ImagenComprobante { get; set; }

    public bool? Eliminado { get; set; }

    public string? TipoImagen { get; set; }

    public bool? EnviadoAfacturar { get; set; }

    public decimal? PagaCon { get; set; }

    public virtual ICollection<DetallesRecibo> DetallesRecibos { get; set; } = new List<DetallesRecibo>();

    public virtual TipoEstadoPago? IdEstadoPagoNavigation { get; set; }

    public virtual Servicio? IdServicioNavigation { get; set; }
}
