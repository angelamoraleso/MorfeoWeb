using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class HistorialPago
{
    public int IdPago { get; set; }

    public int? IdReserva { get; set; }

    public DateOnly? FechaPago { get; set; }

    public decimal? Monto { get; set; }

    public int? IdTipoPago { get; set; }

    public int? IdMetodoPago { get; set; }

    public int? IdEstadoPagado { get; set; }

    public virtual EstadoPago? IdEstadoPagadoNavigation { get; set; }

    public virtual MetodoPago? IdMetodoPagoNavigation { get; set; }

    public virtual Reserva? IdReservaNavigation { get; set; }

    public virtual TipoPago? IdTipoPagoNavigation { get; set; }
}
