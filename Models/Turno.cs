using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Turno
{
    public int IdTurno { get; set; }

    public string? NombreTurno { get; set; }

    public TimeOnly? HoraInicio { get; set; }

    public TimeOnly? HoraFin { get; set; }

    public virtual ICollection<AsignarTurno> AsignarTurnos { get; set; } = new List<AsignarTurno>();
}
