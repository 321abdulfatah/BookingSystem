using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem.Branches;

public class BranchDateSchedule : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid BranchId { get; set; }
    public virtual Branch? Branch { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid? TenantId { get; set; }

    public virtual ICollection<BranchTimeSchedule>? BranchTimeSchedules { get; set; }
}
