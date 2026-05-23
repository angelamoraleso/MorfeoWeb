using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class Contrato
{
    public int IdContrato { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public decimal? Salario { get; set; }

    public int? IdEmpleado { get; set; }

    public int? IdCargo { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdTipoContrato { get; set; }

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }

    public virtual TipoContrato? IdTipoContratoNavigation { get; set; }
}
