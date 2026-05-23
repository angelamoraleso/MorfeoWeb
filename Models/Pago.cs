using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdReserva { get; set; }

    public decimal? Monto { get; set; }

    public string? TipoPago { get; set; }

    public string? MetodoPago { get; set; }

    public string? Estado { get; set; }
}
