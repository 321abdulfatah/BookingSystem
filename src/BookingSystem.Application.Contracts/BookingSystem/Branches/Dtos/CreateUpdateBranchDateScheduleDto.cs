using System;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class CreateUpdateBranchDateScheduleDto
{
    [Required]
    public Guid BranchId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
}