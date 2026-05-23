using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class CategoriaEstrella
{
    public int IdEstrellas { get; set; }

    public string? Nivel { get; set; }

    public virtual ICollection<HistorialCategoria> HistorialCategoria { get; set; } = new List<HistorialCategoria>();
}
