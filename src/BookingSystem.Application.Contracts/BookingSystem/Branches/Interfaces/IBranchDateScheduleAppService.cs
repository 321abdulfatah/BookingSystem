using BookingSystem.BookingSystem.Branches.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookingSystem.BookingSystem.Branches.Interfaces;

public interface IBranchDateScheduleAppService :
    ICrudAppService< //Defines CRUD methods
        BranchDateScheduleDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBranchDateScheduleDto> //Used to create/update a book
{

}