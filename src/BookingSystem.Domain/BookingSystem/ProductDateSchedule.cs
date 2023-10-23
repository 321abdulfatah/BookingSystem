using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem;

public class ProductDateSchedule : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid ProductBranchId { get; set; }

    public virtual ProductBranch? ProductBranch { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Guid? TenantId { get; set; }

    public virtual ICollection<ProductTimeSchedule>? ProductTimeSchedules { get; set; }

}

