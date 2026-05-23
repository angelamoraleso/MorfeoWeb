namespace MorfeoWeb.Models;

public partial class TelefonoHotel
{
    public int IdTelefonoHotel { get; set; }
    public string? Numero { get; set; }
    public int? IdHotel { get; set; }

    public virtual Hotel? IdHotelNavigation { get; set; }
}