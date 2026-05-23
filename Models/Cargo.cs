using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string? NombreCargo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
