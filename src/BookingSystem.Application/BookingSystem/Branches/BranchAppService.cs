using BookingSystem.BookingSystem.Branches.Dtos;
using BookingSystem.BookingSystem.Branches.Interfaces;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.BookingSystem.Branches;

public class BranchAppService :
CrudAppService<
    Branch, //The Book entity
    BranchDto, //Used to show branches
    Guid, //Primary key of the branch entity
    PagedAndSortedResultRequestDto, //Used for paging/sorting
    CreateUpdateBranchDto>, //Used to create/update a branch
IBranchAppService //implement the IBookAppService
{
    public BranchAppService(IRepository<Branch, Guid> repository)
        : base(repository)
    {

    }
}