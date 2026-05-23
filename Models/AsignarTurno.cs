using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class AsignarTurno
{
    public int IdAsignacionTurno { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdTurno { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Turno? IdTurnoNavigation { get; set; }
}
