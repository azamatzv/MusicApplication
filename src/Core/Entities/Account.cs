using Core.Common;

namespace Core.Entities;

public class Account : BaseEntity, IAuditedEntity
{
    public required string Name { get; set; }

    public TariffType TariffType { get; set; }
    
    public Guid TariffId { get; set; }

    public int Balance { get; set; }

    public Users User { get; set; }
    
    public Guid UserId { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}