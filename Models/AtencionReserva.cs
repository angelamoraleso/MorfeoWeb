using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class AtencionReserva
{
    public int IdAtencion { get; set; }

    public DateOnly? FechaAtencion { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdReserva { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }
}
