using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class RecursosHumano
{
    public string? Nombre { get; set; }

    public string? Documento { get; set; }

    public string? NombreCargo { get; set; }

    public string? NombreDepartamento { get; set; }

    public decimal? Salario { get; set; }
}
