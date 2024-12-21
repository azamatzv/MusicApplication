namespace Application.Models.Users;

public class CreateUserModel
{
    public Guid TariffId { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
}