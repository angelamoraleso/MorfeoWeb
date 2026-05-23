using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class HistorialCategoria
{
    public int IdHistoriaCategor { get; set; }

    public int? IdHotel { get; set; }

    public DateOnly? FechaCambio { get; set; }

    public string? MotivoCambio { get; set; }

    public int? IdEstrellas { get; set; }

    public virtual CategoriaEstrella? IdEstrellasNavigation { get; set; }

    public virtual Hotel? IdHotelNavigation { get; set; }
}
