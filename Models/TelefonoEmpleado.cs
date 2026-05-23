using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class TelefonoEmpleado
{
    public int IdTelefonoEmpleado { get; set; }
    public string? Numero { get; set; }
    public int? IdEmpleado { get; set; }

    // Navegación hacia Empleado (coincide con la configuración en OnModelCreating)
    public virtual Empleado? IdEmpleadoNavigation { get; set; }

}