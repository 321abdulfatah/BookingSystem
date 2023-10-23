using BookingSystem.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookingSystem.Permissions;

public class BookingSystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookingSystemPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookingSystemPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookingSystemResource>(name);
    }
}
