using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class TipoServicio
{
    public int IdTipoServicio { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ServicioAdicional> ServicioAdicionals { get; set; } = new List<ServicioAdicional>();
}
