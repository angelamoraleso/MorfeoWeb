using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class InformacionHabitacion
{
    public int IdHabitacion { get; set; }

    public int? Capacidad { get; set; }

    public decimal? PrecioNoche { get; set; }

    public string? Categoria { get; set; }

    public string? NombreEstado { get; set; }
}
