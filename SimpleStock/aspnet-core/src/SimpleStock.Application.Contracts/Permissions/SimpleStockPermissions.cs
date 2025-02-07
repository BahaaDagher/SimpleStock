namespace SimpleStock.Permissions;

public static class SimpleStockPermissions
{
    public const string MainGroupName = "SimpleStock";

    // product group permission
    public const string ProductGroupName = MainGroupName  + ".Products";

    // product permission
    public const string CreateEditProductPermission = ProductGroupName + ".CreateEdit"; 
    public const string DeleteProductPermission = ProductGroupName + ".Delete"; 
    public const string GetProductPermission = ProductGroupName + ".Get"; 
    public const string ListProductPermission = ProductGroupName + ".List";




}
