using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Mascotum
{
    public int IdMascota { get; set; }

    public string? Nombre { get; set; }

    public int? IdTipo { get; set; }

    public int? IdHuesped { get; set; }

    public virtual Huesped? IdHuespedNavigation { get; set; }

    public virtual TipoMascotum? IdTipoNavigation { get; set; }
}
