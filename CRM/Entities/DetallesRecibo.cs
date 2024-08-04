using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class DetallesRecibo
{
    public int IdDetalleRecibo { get; set; }

    public int? IdRecibo { get; set; }

    public int? IdPago { get; set; }

    public decimal? MontoLinea { get; set; }

    public bool? Anulado { get; set; }

    public bool? AnuladoParcial { get; set; }

    public virtual Pago? IdPagoNavigation { get; set; }

    public virtual Recibo? IdReciboNavigation { get; set; }
}
