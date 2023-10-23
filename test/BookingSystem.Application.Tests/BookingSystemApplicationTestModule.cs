using Volo.Abp.Modularity;

namespace BookingSystem;

[DependsOn(
    typeof(BookingSystemApplicationModule),
    typeof(BookingSystemDomainTestModule)
    )]
public class BookingSystemApplicationTestModule : AbpModule
{

}
