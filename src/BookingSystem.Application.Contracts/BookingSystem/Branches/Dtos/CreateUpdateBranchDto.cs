using System.ComponentModel.DataAnnotations;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class CreateUpdateBranchDto
{
    [Required]
    [StringLength(50)]
    public string BranchName { get; set; }

    [Required]
    [StringLength(255)]
    public string BranchLocation { get; set; }
}