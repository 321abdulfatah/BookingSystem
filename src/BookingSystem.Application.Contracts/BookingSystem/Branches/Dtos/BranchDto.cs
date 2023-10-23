using System;
using Volo.Abp.Application.Dtos;

namespace BookingSystem.BookingSystem.Branches.Dtos;

public class BranchDto : AuditedEntityDto<Guid>
{
    public  string BranchName { get; set; }
    public  string BranchLocation { get; set; }
}