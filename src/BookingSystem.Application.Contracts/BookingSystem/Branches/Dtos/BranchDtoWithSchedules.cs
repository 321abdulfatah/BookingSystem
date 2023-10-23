using System.Collections.Generic;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class BranchDtoWithSchedules : BranchDto
{
    public  ICollection<BranchDateScheduleDto>? BranchDateSchedules { get; set; }
}

