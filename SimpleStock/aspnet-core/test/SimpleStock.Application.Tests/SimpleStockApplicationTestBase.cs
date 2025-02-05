using Volo.Abp.Modularity;

namespace SimpleStock;

public abstract class SimpleStockApplicationTestBase<TStartupModule> : SimpleStockTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
