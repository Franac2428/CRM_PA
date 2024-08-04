using System;
using System.Collections.Generic;

namespace CRM.Entities;

public partial class TipoIdentificacion
{
    public int IdTipoIdentificacion { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<InfoEmpresa> InfoEmpresas { get; set; } = new List<InfoEmpresa>();
}
