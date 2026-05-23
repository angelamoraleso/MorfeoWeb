using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class MetodoPago
{
    public int IdMetodoPago { get; set; }

    public string? MetodoPago1 { get; set; }

    public virtual ICollection<HistorialPago> HistorialPagos { get; set; } = new List<HistorialPago>();
}
