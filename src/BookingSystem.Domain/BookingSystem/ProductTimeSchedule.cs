using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.BookingSystem;

public class ProductTimeSchedule : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid ProductDateScheduleId { get; set; }

    public virtual ProductDateSchedule? ProductDateSchedule { get; set; }

    public required string DayOfWeek { get; set; }

    public TimeSpan OpeningTime { get; set; }

    public TimeSpan ClosingTime { get; set; }

    public string? Description { get; set; }

    public Guid? TenantId { get; set; }
}

