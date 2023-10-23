using BookingSystem.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookingSystem.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BookingSystemEntityFrameworkCoreModule),
    typeof(BookingSystemApplicationContractsModule)
    )]
public class BookingSystemDbMigratorModule : AbpModule
{
}
