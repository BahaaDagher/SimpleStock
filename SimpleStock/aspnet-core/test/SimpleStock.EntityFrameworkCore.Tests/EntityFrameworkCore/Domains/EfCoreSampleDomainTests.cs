using SimpleStock.Samples;
using Xunit;

namespace SimpleStock.EntityFrameworkCore.Domains;

[Collection(SimpleStockTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SimpleStockEntityFrameworkCoreTestModule>
{

}
