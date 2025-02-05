using Volo.Abp.Modularity;

namespace SimpleStock;

[DependsOn(
    typeof(SimpleStockDomainModule),
    typeof(SimpleStockTestBaseModule)
)]
public class SimpleStockDomainTestModule : AbpModule
{

}
