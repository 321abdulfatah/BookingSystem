using BookingSystem.BookingSystem.BookingShared;
using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem;

public class Booking : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid ProductBranchId { get; set; }

    public virtual ProductBranch? ProductBranch { get; set; }

    public DateTime BookingDate { get; set; }

    public TimeSpan BookingStartTime { get; set; }

    public int Duration { get; set; }

    public Status Status { get; set; }

    public Guid? TenantId { get; set; }
}