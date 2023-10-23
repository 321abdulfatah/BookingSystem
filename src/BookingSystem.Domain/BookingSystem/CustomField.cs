using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem;

public class CustomField : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid ProductBranchId { get; set; }

    public virtual ProductBranch? ProductBranch { get; set; }

    public string? FieldTitle { get; set; }

    public string? FieldPlaceholder { get; set; }

    public string? FieldType { get; set; }

    public bool FieldRequired { get; set; }

    public Guid? TenantId { get; set; }
}

