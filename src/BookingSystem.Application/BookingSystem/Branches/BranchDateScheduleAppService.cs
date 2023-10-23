using BookingSystem.BookingSystem.Branches.Dtos;
using BookingSystem.BookingSystem.Branches.Interfaces;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.BookingSystem.Branches;

public class BranchDateScheduleAppService :
    CrudAppService<
    BranchDateSchedule, //The Book entity
    BranchDateScheduleDto, //Used to show branches
    Guid, //Primary key of the branch entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateBranchDateScheduleDto>, //Used to create/update a branch
IBranchDateScheduleAppService//implement the IBookAppService
{
    public BranchDateScheduleAppService(IRepository<BranchDateSchedule, Guid> repository)
        : base(repository)
    {

    }
}