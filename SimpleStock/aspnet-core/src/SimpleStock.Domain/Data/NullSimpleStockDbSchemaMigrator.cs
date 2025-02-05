using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SimpleStock.Data;

/* This is used if database provider does't define
 * ISimpleStockDbSchemaMigrator implementation.
 */
public class NullSimpleStockDbSchemaMigrator : ISimpleStockDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
