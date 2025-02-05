
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStock;
using SimpleStock.Categories;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SimpleStock.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // to make a configuration to all the data which added by FullAuditedEntity
            builder.ConfigureByConvention();
            builder.Property(x=>x.Id).ValueGeneratedNever();

            builder.Property(x => x.NameAr).HasMaxLength(SimpleStockConsts.GeneralTextMaxLength);
            builder.Property(x => x.NameEn).HasMaxLength(SimpleStockConsts.GeneralTextMaxLength);
            builder.Property(x => x.DescriptionAr).HasMaxLength(SimpleStockConsts.GeneralDescriptionMaxLength);
            builder.Property(x => x.DescriptionEn).HasMaxLength(SimpleStockConsts.GeneralDescriptionMaxLength);

            builder.ToTable("Categories"); 
        }
    }
}
