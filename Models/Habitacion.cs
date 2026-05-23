using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public int? Capacidad { get; set; }

    public decimal? PrecioNoche { get; set; }

    public int? IdEstado { get; set; }

    public int? IdTipoHabitacion { get; set; }

    public int? IdHotel { get; set; }

    public virtual ICollection<AsignarHabitacion> AsignarHabitacions { get; set; } = new List<AsignarHabitacion>();

    public virtual ICollection<AsignarLimpieza> AsignarLimpiezas { get; set; } = new List<AsignarLimpieza>();

    public virtual EstadoHabitacion? IdEstadoNavigation { get; set; }

    public virtual Hotel? IdHotelNavigation { get; set; }

    public virtual TipoHabitacion? IdTipoHabitacionNavigation { get; set; }
}
