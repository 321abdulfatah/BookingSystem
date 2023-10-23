using System;
using Volo.Abp.Application.Dtos;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class BranchDateScheduleDto : AuditedEntityDto<Guid>
{
    public Guid BranchId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
