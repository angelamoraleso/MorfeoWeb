using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Localidad
{
    public int IdLocalidad { get; set; }

    public string? NombreLocalidad { get; set; }

    public string? CodigoPostal { get; set; }

    public int? IdCiudad { get; set; }

    public virtual ICollection<Barrio> Barrios { get; set; } = new List<Barrio>();

    public virtual Ciudad? IdCiudadNavigation { get; set; }
}
