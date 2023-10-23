using Volo.Abp.Settings;

namespace BookingSystem.Settings;

public class BookingSystemSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookingSystemSettings.MySetting1));
    }
}
