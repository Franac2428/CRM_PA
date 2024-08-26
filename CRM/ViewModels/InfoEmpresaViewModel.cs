﻿using System;
using System.Collections.Generic;

namespace CRM.APIModels;

public class InfoEmpresaViewModel
{
    public int IdInfoEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Actividad { get; set; }

    public int? IdTipoIdentificacion { get; set; }

    public string? Identificacion { get; set; }
}