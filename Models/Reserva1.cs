using System;
using System.ComponentModel.DataAnnotations;

namespace MorfeoWeb.Models;

public partial class Reserva1
{
    // Como es una vista, no tiene una llave primaria real definida en el modelo, 
    // pero Entity Framework necesita que los campos existan.

    public int IdReserva { get; set; }

    public DateTime? FechaInicio { get; set; }

    public decimal? Total { get; set; }

    public string? Agencia { get; set; }

    public string? Huesped { get; set; }
}