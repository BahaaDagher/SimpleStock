using SimpleStock.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SimpleStock.Permissions;

public class SimpleStockPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SimpleStockPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SimpleStockPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SimpleStockResource>(name);
    }
}
