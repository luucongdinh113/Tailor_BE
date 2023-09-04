using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Domain.Entities
{
    public class ProductCategory : BaseEnity<int>
    {
        public string Name { get; set; } = default!;
        public ICollection<Product> Products{ get; set; } = new Collection<Product>();
        public ICollection<Sample> Samples{ get; set; } = new Collection<Sample>();
    }
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasMany(c => c.Products).WithOne(c => c.ProductCategory).HasForeignKey(product=>product.ProductCategoryId);
            builder.HasMany(c => c.Samples).WithOne(c => c.ProductCategory).HasForeignKey(sample=>sample.ProductCategoryId);
        }
    }
}
