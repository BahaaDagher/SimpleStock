using Xunit;

namespace SimpleStock.EntityFrameworkCore;

[CollectionDefinition(SimpleStockTestConsts.CollectionDefinitionName)]
public class SimpleStockEntityFrameworkCoreCollection : ICollectionFixture<SimpleStockEntityFrameworkCoreFixture>
{

}
