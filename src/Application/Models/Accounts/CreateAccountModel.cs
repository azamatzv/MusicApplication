using Core.Entities;

namespace Application.Models.Accounts;

public class CreateAccountModel
{
    public string Name { get; set; }
    public TariffType TariffType { get; set; }
    public int Balance { get; set; }
    public Guid UserId { get; set; }
}