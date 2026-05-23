using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class EstadoLimpieza
{
    public int IdEstadoLimpieza { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<AsignarLimpieza> AsignarLimpiezas { get; set; } = new List<AsignarLimpieza>();
}
