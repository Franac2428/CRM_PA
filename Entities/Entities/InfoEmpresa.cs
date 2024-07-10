using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class InfoEmpresa
{
    public int IdInfoEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Actividad { get; set; }

    public int? IdTipoIdentificacion { get; set; }

    public string? Identificacion { get; set; }

    public virtual TipoIdentificacion? IdTipoIdentificacionNavigation { get; set; }
}
