using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleStock;
using SimpleStock.Products;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SimpleStock.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(x => x.NameAr).HasMaxLength(SimpleStockConsts.GeneralTextMaxLength);
            builder.Property(x => x.NameEn).HasMaxLength(SimpleStockConsts.GeneralTextMaxLength);
            builder.Property(x => x.DescriptionAr).HasMaxLength(SimpleStockConsts.GeneralDescriptionMaxLength);
            builder.Property(x => x.DescriptionEn).HasMaxLength(SimpleStockConsts.GeneralDescriptionMaxLength);

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .IsRequired(); 

            builder.ToTable("Products");
        }
    }
}
