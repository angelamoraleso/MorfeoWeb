using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class AsignarLimpieza
{
    public int IdAsignacionLimpieza { get; set; }

    public DateOnly? FechaAsignacion { get; set; }

    public DateOnly? FechaRealizada { get; set; }

    public int? IdEstadoLimpieza { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdHabitacion { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual EstadoLimpieza? IdEstadoLimpiezaNavigation { get; set; }

    public virtual Habitacion? IdHabitacionNavigation { get; set; }
}
