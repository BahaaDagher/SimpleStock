using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SimpleStock;

[Dependency(ReplaceServices = true)]
public class SimpleStockBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SimpleStock";
}
