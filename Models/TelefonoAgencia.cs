namespace MorfeoWeb.Models;

public partial class TelefonoAgencia
{
    public int IdTelefonoAgencia { get; set; }
    public string? Numero { get; set; }
    public int? IdAgencia { get; set; }

    public virtual AgenciaViaje? IdAgenciaNavigation { get; set; }
}