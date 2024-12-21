using Core.Common;

namespace Core.Entities;

public class Users : BaseEntity, IAuditedEntity
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public Role Role { get; set; } = Role.User;

    public ICollection<Account> Accounts { get; set; }

    public ICollection<Card> Cards { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}



public enum Role
{
    User = 1,
    Admin = 2
}