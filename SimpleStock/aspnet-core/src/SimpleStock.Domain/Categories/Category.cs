using Volo.Abp.Domain.Entities.Auditing;

namespace SimpleStock.Categories
{
    public  class Category : FullAuditedEntity<int>
    {
        public Category()
        {
        }
        public Category(string nameAR, string nameEn, string descriptionAr, string descriptionEn)
        {
            NameAr = nameAR;
            NameEn = nameEn;
            DescriptionAr = descriptionAr;
            DescriptionEn = descriptionEn;
        }
        public string NameAr {  get; set; }
        public string NameEn {  get; set; }
        public string DescriptionAr {  get; set; }
        public string DescriptionEn {  get; set; }
    }
}
