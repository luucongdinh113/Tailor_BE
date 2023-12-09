using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Domain.Entities
{
    public class UserSample: BaseEnity<int>
    {
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        [ForeignKey(nameof(SampleId))]
        public int SampleId { get; set; }
        public Sample Sample { get; set; } = default!;
    }
    public class UserSampleConfiguration : IEntityTypeConfiguration<UserSample>
    {
        public void Configure(EntityTypeBuilder<UserSample> builder)
        {
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
