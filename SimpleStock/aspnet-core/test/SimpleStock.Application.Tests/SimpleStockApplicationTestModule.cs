using Volo.Abp.Modularity;

namespace SimpleStock;

[DependsOn(
    typeof(SimpleStockApplicationModule),
    typeof(SimpleStockDomainTestModule)
)]
public class SimpleStockApplicationTestModule : AbpModule
{

}
