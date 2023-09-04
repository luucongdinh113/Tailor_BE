using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ICollection<UserSample> User_Samples { get; set; } = new Collection<UserSample>();
    }
    public class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.HasMany(c => c.User_Samples).WithOne(c => c.Sample).HasForeignKey(sample=> sample.SampleId);
        }
    }
}
