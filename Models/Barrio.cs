using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MorfeoWeb.Models;

public partial class Barrio
{
    public int IdBarrio { get; set; }
     [Required(ErrorMessage = "El nombre del barrio es obligatorio")]
    [StringLength(100)]
    public string nombre_barrio { get; set; } = string.Empty; // NOT NULL

    public int? IdLocalidad { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual Localidad? IdLocalidadNavigation { get; set; }
}
