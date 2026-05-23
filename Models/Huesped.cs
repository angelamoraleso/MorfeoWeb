using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Huesped
{
    public int IdHuesped { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Documento { get; set; }

    public int? IdTipoHuesped { get; set; }

    public int? IdPais { get; set; }

    public virtual ICollection<AsignarHabitacion> AsignarHabitacions { get; set; } = new List<AsignarHabitacion>();

    public virtual Pai? IdPaisNavigation { get; set; }

    public virtual TipoHuesped? IdTipoHuespedNavigation { get; set; }

    public virtual ICollection<Mascotum> Mascota { get; set; } = new List<Mascotum>();

    public virtual ICollection<TelefonoHuesped> TelefonoHuespeds { get; set; } = new List<TelefonoHuesped>();
}
