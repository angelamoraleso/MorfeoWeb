using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public decimal? AnticipoPagado { get; set; }

    public DateOnly? FechaReserva { get; set; }

    public decimal? Total { get; set; }

    public int? IdAgencia { get; set; }

    public virtual ICollection<AsignarHabitacion> AsignarHabitacions { get; set; } = new List<AsignarHabitacion>();

    public virtual ICollection<AtencionReserva> AtencionReservas { get; set; } = new List<AtencionReserva>();

    public virtual ICollection<DetalleServicioReserva> DetalleServicioReservas { get; set; } = new List<DetalleServicioReserva>();

    public virtual ICollection<HistorialPago> HistorialPagos { get; set; } = new List<HistorialPago>();

    public virtual AgenciaViaje? IdAgenciaNavigation { get; set; }
}
