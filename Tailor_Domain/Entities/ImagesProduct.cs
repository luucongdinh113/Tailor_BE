using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    public class ImagesProduct : BaseEnity<int>
    {
        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public string LinkImage { get; set; } = default!;

    }
    public class ImagesProductConfiguration : IEntityTypeConfiguration<ImagesProduct>
    {
        public void Configure(EntityTypeBuilder<ImagesProduct> builder)
        {
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted ==null);
        }
    }
}
