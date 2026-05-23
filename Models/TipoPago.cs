using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class TipoPago
{
    public int IdTipoPago { get; set; }

    public string? TipoPago1 { get; set; }

    public virtual ICollection<HistorialPago> HistorialPagos { get; set; } = new List<HistorialPago>();
}
