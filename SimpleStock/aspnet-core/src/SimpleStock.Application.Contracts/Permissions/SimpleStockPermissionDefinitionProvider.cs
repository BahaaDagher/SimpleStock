using SimpleStock.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SimpleStock.Permissions;

public class SimpleStockPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SimpleStockPermissions.MainGroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SimpleStockPermissions.MyPermission1, L("Permission:MyPermission1"));

        var productGroup = context.AddGroup(SimpleStockPermissions.ProductGroupName, L("SimpleStock.Products"));

        productGroup.AddPermission(SimpleStockPermissions.CreateEditProductPermission, L("Permission:Products:CreateEditProduct")); 
        productGroup.AddPermission(SimpleStockPermissions.DeleteProductPermission, L("Permission:Products:DeleteProduct")); 
        productGroup.AddPermission(SimpleStockPermissions.GetProductPermission, L("Permission:Products:GetProduct")); 
        productGroup.AddPermission(SimpleStockPermissions.ListProductPermission, L("Permission:Products:ListProduct")); 
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SimpleStockResource>(name);
    }
}
