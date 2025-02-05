using System;
using System.Collections.Generic;
using System.Text;
using SimpleStock.Localization;
using Volo.Abp.Application.Services;

namespace SimpleStock;

/* Inherit your application services from this class.
 */
public abstract class SimpleStockAppService : ApplicationService
{
    protected SimpleStockAppService()
    {
        LocalizationResource = typeof(SimpleStockResource);
    }
}
