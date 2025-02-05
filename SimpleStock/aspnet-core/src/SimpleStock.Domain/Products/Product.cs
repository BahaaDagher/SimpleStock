using SimpleStock.Categories;
using Volo.Abp.Domain.Entities.Auditing;

namespace SimpleStock.Products
{
    public class Product : FullAuditedEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DesciptionAr { get; set; }
        public string DesciptionEn { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
