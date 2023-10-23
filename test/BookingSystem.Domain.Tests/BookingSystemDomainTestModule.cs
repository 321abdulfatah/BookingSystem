using BookingSystem.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookingSystem;

[DependsOn(
    typeof(BookingSystemEntityFrameworkCoreTestModule)
    )]
public class BookingSystemDomainTestModule : AbpModule
{

}
