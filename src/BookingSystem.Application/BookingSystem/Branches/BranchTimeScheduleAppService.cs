using BookingSystem.BookingSystem.Branches.Dtos;
using BookingSystem.BookingSystem.Branches.Interfaces;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.BookingSystem.Branches;

public class BranchTimeScheduleAppService :
    CrudAppService<
    BranchTimeSchedule, //The Book entity
    BranchTimeScheduleDto, //Used to show branches
    Guid, //Primary key of the branch entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateBranchTimeScheduleDto>, //Used to create/update a branch
IBranchTimeScheduleAppService//implement the IBookAppService
{
    public BranchTimeScheduleAppService(IRepository<BranchTimeSchedule, Guid> repository)
        : base(repository)
    {

    }
}

