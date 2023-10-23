using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem.Branches;

public class BranchTimeSchedule : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid BranchDateScheduleId { get; set; }
    public virtual BranchDateSchedule? BranchDateSchedule { get; set; }
    public required string DayOfWeek { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public bool IsWorkingDay { get; set; }
    public string? Description { get; set; }
    public Guid? TenantId { get; set; }
}
