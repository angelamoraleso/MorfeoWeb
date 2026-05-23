using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class TipoHabitacion
{
    public int IdTipoHabitacion { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();
}
