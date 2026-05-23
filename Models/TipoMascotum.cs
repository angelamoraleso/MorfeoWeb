using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class TipoMascotum
{
    public int IdTipo { get; set; }

    public string? TipoMascota { get; set; }

    public virtual ICollection<Mascotum> Mascota { get; set; } = new List<Mascotum>();
}
