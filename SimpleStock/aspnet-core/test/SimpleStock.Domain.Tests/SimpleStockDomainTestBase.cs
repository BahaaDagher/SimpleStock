using Volo.Abp.Modularity;

namespace SimpleStock;

/* Inherit from this class for your domain layer tests. */
public abstract class SimpleStockDomainTestBase<TStartupModule> : SimpleStockTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
