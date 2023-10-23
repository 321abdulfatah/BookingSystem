using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class CreateUpdateBranchTimeScheduleDto
{
    [Required]
    public Guid BranchDateScheduleId { get; set; }

    [Required]
    [MaxLength(10)]
    public string DayOfWeek { get; set; }

    [Required]
    public TimeSpan OpeningTime { get; set; }

    [Required]
    public TimeSpan ClosingTime { get; set; }

    [Required]
    public bool IsWorkingDay { get; set; }

    public string Description { get; set; }
}
