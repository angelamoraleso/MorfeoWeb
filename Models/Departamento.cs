using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? NombreDepartamento { get; set; }

    public int? IdHotel { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual Hotel? IdHotelNavigation { get; set; }
}
