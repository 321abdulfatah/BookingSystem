using System;
using Volo.Abp.Application.Dtos;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class BranchTimeScheduleDto : AuditedEntityDto<Guid>
{
    public Guid BranchDateScheduleId { get; set; }
    public string DayOfWeek { get; set; }
    public TimeSpan OpeningTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public bool IsWorkingDay { get; set; }
    public string? Description { get; set; }
}