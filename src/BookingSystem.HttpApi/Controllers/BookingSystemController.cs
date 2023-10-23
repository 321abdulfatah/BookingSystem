using BookingSystem.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BookingSystem.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookingSystemController : AbpControllerBase
{
    protected BookingSystemController()
    {
        LocalizationResource = typeof(BookingSystemResource);
    }
}
