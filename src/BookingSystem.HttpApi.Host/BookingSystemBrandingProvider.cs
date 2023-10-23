using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BookingSystem;

[Dependency(ReplaceServices = true)]
public class BookingSystemBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BookingSystem";
}
