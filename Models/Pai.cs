using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Pai
{
    public int IdPais { get; set; }

    public string? NombrePais { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();

    public virtual ICollection<Huesped> Huespeds { get; set; } = new List<Huesped>();
}
