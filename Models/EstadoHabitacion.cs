using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class EstadoHabitacion
{
    public int IdEstado { get; set; }

    public string? NombreEstado { get; set; }

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();
}
