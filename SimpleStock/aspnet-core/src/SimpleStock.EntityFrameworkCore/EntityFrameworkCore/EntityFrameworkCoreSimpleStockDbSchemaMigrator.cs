using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleStock.Data;
using Volo.Abp.DependencyInjection;

namespace SimpleStock.EntityFrameworkCore;

public class EntityFrameworkCoreSimpleStockDbSchemaMigrator
    : ISimpleStockDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSimpleStockDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SimpleStockDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SimpleStockDbContext>()
            .Database
            .MigrateAsync();
    }
}
