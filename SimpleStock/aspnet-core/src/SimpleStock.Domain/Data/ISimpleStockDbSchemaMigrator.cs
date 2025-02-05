using System.Threading.Tasks;

namespace SimpleStock.Data;

public interface ISimpleStockDbSchemaMigrator
{
    Task MigrateAsync();
}
