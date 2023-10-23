using BookingSystem.BookingSystem.Branches.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookingSystem.BookingSystem.Branches.Interfaces;

public interface IBranchTimeScheduleAppService :
    ICrudAppService< //Defines CRUD methods
        BranchTimeScheduleDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBranchTimeScheduleDto> //Used to create/update a book
{

}