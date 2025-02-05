using SimpleStock.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SimpleStock.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SimpleStockController : AbpControllerBase
{
    protected SimpleStockController()
    {
        LocalizationResource = typeof(SimpleStockResource);
    }
}
