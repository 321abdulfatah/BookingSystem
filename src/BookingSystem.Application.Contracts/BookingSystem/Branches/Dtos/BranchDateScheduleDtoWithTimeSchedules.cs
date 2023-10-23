using System.Collections.Generic;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class BranchDateScheduleDtoWithTimeSchedules : BranchDateScheduleDto
{
    public ICollection<BranchTimeScheduleDto> BranchTimeSchedules { get; set; }
}
