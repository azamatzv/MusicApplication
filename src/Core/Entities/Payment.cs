using Core.Common;

namespace Core.Entities;

public class Payment : BaseEntity, IAuditedEntity
{
    public Card Cards { get; set; }
    public Guid CardsId { get; set; }

    public Account Accounts { get; set; }
    public Guid AccountsId { get; set; }

    public TariffType TariffType { get; set; }
    public Guid TarifId { get; set; }

    public bool IsPaid { get; set; } = true;

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}