using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    public class Sample: BaseEnity<int>
    {
        [ForeignKey(nameof(ProductCategoryId))]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; } = default!;

        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public string Note { get; set; } =default!;
        public double Price { get; set; }
        public bool IsMale { get; set; }
        public bool IsShow { get; set; }
        public List<UserSample> User_Samples { get; set; } = new List<UserSample>();
    }
    public class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.HasMany(c => c.User_Samples).WithOne(c => c.Sample).HasForeignKey(sample=> sample.SampleId);
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
