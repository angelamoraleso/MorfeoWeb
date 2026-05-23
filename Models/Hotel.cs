using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Hotel
{
    public int IdHotel { get; set; }

    public string? Nombre { get; set; }

    public int? AnioInaguracion { get; set; }

    public int? IdBarrio { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Habitacion> Habitacions { get; set; } = new List<Habitacion>();

    public virtual ICollection<HistorialCategoria> HistorialCategoria { get; set; } = new List<HistorialCategoria>();

    public virtual Barrio? IdBarrioNavigation { get; set; }

    public virtual ICollection<TelefonoHotel> TelefonoHotels { get; set; } = new List<TelefonoHotel>();
    
}
