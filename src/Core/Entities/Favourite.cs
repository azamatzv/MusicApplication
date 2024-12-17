using Core.Common;

namespace Core.Entities;

public class Favourite : BaseEntity, IAuditedEntity
{
    public Music Music { get; set; }
    public Guid MusicId { get; set; }

    public Account Accounts { get; set; }
    public Guid AccountsId { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}