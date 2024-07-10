﻿using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Saldo
{
    public int IdSaldo { get; set; }

    public int? IdCliente { get; set; }

    public decimal? MontoSaldo { get; set; }

    public int? IdMoneda { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual TipoMoneda? IdMonedaNavigation { get; set; }
}