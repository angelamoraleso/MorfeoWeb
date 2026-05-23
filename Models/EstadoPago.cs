using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class EstadoPago
{
    public int IdEstadoPago { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<HistorialPago> HistorialPagos { get; set; } = new List<HistorialPago>();
}
