using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    //status: todo, doing, done, complete
    public class Task: BaseEnity<int>
    {
        [ForeignKey(nameof(UserId))]
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(SampleId))]
        public int? SampleId { get; set; }
        public Sample? Sample { get; set; }

        [ForeignKey(nameof(ProductId))]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public string Content { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }
        public int Index{ get; set; } = default!;
        public bool IsUseCloth { get; set; }
        public string Note { get; set; } = default!;
        public int Percent { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? DoneDate { get; set; }
        public List<Notify> Notifies { get; set; } = default!;
    }
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasMany(c => c.Notifies).WithOne(c => c.Task).HasForeignKey(notify=>notify.TaskId);
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
