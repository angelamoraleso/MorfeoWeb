namespace MorfeoWeb.Models;

public partial class TelefonoHuesped
{
    public int IdTelefonoHuesped { get; set; }
    public string? Numero { get; set; }
    public int? IdHuesped { get; set; }

    public virtual Huesped? IdHuespedNavigation { get; set; }
}