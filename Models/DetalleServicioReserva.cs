using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class DetalleServicioReserva
{
    public int IdReserva { get; set; }

    public int IdServicio { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public int? Cantidad { get; set; }

    public virtual Reserva IdReservaNavigation { get; set; } = null!;

    public virtual ServicioAdicional IdServicioNavigation { get; set; } = null!;
}
