﻿using Core.Common;

namespace Core.Entities;

public class User : BaseEntity, IAuditedEntity
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Address { get; set; }

    public required string PassportId { get; set; }

    public ICollection<Card> Cards { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}