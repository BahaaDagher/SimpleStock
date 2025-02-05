using SimpleStock.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SimpleStock.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SimpleStockEntityFrameworkCoreModule),
    typeof(SimpleStockApplicationContractsModule)
    )]
public class SimpleStockDbMigratorModule : AbpModule
{
}
