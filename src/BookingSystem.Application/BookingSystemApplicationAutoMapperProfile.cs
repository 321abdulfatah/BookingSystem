using AutoMapper;
using BookingSystem.BookingSystem;
using BookingSystem.BookingSystem.Branches;
using BookingSystem.BookingSystem.Branches.Dtos;

namespace BookingSystem;

public class BookingSystemApplicationAutoMapperProfile : Profile
{
    public BookingSystemApplicationAutoMapperProfile()
    {
        // Mapping from Branch entity to BranchDto
        CreateMap<Branch, BranchDto>();

        // Mapping from CreateUpdateBranchDto (DTO for creating or updating a Branch) to Branch entity
        CreateMap<CreateUpdateBranchDto, Branch>();

        // Mapping from Branch entity to BranchDtoWithSchedules, including BranchDateSchedules
        CreateMap<Branch, BranchDtoWithSchedules>()
            .ForMember(dest => dest.BranchDateSchedules, opt => opt.MapFrom(src => src.BranchDateSchedules));

        // Mapping from BranchDateSchedule entity to BranchDateScheduleDto
        CreateMap<BranchDateSchedule, BranchDateScheduleDto>();

        // Mapping from BranchDateSchedule entity to BranchDateScheduleDtoWithTimeSchedules, including BranchTimeSchedules
        CreateMap<BranchDateSchedule, BranchDateScheduleDtoWithTimeSchedules>()
            .ForMember(dest => dest.BranchTimeSchedules, opt => opt.MapFrom(src => src.BranchTimeSchedules));

        // Mapping from BranchTimeSchedule entity to BranchTimeScheduleDto
        CreateMap<BranchTimeSchedule, BranchTimeScheduleDto>();

    }

}
