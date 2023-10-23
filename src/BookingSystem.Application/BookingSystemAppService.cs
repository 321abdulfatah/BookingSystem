using System;
using System.Collections.Generic;
using System.Text;
using BookingSystem.Localization;
using Volo.Abp.Application.Services;

namespace BookingSystem;

/* Inherit your application services from this class.
 */
public abstract class BookingSystemAppService : ApplicationService
{
    protected BookingSystemAppService()
    {
        LocalizationResource = typeof(BookingSystemResource);
    }
}
