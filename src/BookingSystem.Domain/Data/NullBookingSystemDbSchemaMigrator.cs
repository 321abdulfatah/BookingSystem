using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BookingSystem.Data;

/* This is used if database provider does't define
 * IBookingSystemDbSchemaMigrator implementation.
 */
public class NullBookingSystemDbSchemaMigrator : IBookingSystemDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
