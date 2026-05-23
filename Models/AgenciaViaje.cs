using System;
using System.Collections.Generic;

namespace MorfeoWeb.Models;

public partial class AgenciaViaje
{
    public int IdAgencia { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    // --- NUEVA PROPIEDAD PARA TU TABLA TELEFONO_AGENCIA ---
    public virtual ICollection<TelefonoAgencia> TelefonoAgencias { get; set; } = new List<TelefonoAgencia>();
}