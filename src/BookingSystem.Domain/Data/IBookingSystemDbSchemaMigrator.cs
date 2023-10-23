using System.Threading.Tasks;

namespace BookingSystem.Data;

public interface IBookingSystemDbSchemaMigrator
{
    Task MigrateAsync();
}
