using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tailor_Domain.Entities
{
    public class ProductCategory : BaseEnity<int>
    {
        public string Name { get; set; } = default!;
        public List<Product> Products{ get; set; } = new List<Product>();

        public List<Sample> Samples{ get; set; } = new List<Sample>();
    }
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasMany(c => c.Products).WithOne(c => c.ProductCategory).HasForeignKey(product=>product.ProductCategoryId);
            builder.HasMany(c => c.Samples).WithOne(c => c.ProductCategory).HasForeignKey(sample=>sample.ProductCategoryId);
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
