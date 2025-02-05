using SimpleStock.Samples;
using Xunit;

namespace SimpleStock.EntityFrameworkCore.Applications;

[Collection(SimpleStockTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SimpleStockEntityFrameworkCoreTestModule>
{

}
