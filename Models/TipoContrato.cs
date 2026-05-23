using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class TipoContrato
{
    public int IdTipoContrato { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
