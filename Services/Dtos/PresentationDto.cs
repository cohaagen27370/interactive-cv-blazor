namespace interactiveCvBlazor.Services.Dtos;

public class PresentationDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Profil { get; set; } = string.Empty;
    public AddressDto Address { get; set; } = new();
}