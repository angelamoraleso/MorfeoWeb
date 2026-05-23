using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class ServicioAdicional
{
    public int IdServicio { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public int? IdTipoServicio { get; set; }

    public virtual ICollection<DetalleServicioReserva> DetalleServicioReservas { get; set; } = new List<DetalleServicioReserva>();

    public virtual TipoServicio? IdTipoServicioNavigation { get; set; }
}
