namespace Application.Models.TariffTypes;

public class CreateTariffTypeModel
{
    public required string Name { get; set; }

    public int Amount { get; set; }
}