using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class TipoHuesped
{
    public int IdTipoHuesped { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Huesped> Huespeds { get; set; } = new List<Huesped>();
}
