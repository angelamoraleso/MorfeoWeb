using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Documento { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public DateOnly? FechaContratacion { get; set; }

    public int? IdBarrio { get; set; }

    public int? IdHotel { get; set; }

    public virtual ICollection<AsignarLimpieza> AsignarLimpiezas { get; set; } = new List<AsignarLimpieza>();

    public virtual ICollection<AsignarTurno> AsignarTurnos { get; set; } = new List<AsignarTurno>();

    public virtual ICollection<AtencionReserva> AtencionReservas { get; set; } = new List<AtencionReserva>();

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual Barrio? IdBarrioNavigation { get; set; }

    public virtual Hotel? IdHotelNavigation { get; set; }

    public virtual ICollection<TelefonoEmpleado> TelefonoEmpleados { get; set; } = new List<TelefonoEmpleado>();
}
