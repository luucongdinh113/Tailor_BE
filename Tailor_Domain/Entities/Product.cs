using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    public class Product: BaseEnity<int>
    {
        [ForeignKey(nameof(ProductCategoryId))]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory{ get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public string Note { get; set; } = default!;
        public string NoteCloth { get; set; } = default!;
        public decimal PriceCloth { get; set; } = default!;
        public List<ImagesProduct> ImagesProducts { get; set; } = new List<ImagesProduct>();

    }
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
