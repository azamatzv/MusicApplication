using Core.Common;

namespace Core.Entities;

public class TariffType : BaseEntity, IAuditedEntity
{
    public required string Name { get; set; }

    public int Amount { get; set; }

    public ICollection<Account> Accounts { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}