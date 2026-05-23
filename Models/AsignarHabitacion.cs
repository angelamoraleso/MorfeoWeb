using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class AsignarHabitacion
{
    public int IdAsignacion { get; set; }

    public int? IdHuesped { get; set; }

    public int? IdReserva { get; set; }

    public int? IdHabitacion { get; set; }

    public virtual Habitacion? IdHabitacionNavigation { get; set; }

    public virtual Huesped? IdHuespedNavigation { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }
}
