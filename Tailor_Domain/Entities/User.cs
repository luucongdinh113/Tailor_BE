using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    public class User:BaseEnity<Guid>
    {
        [MinLength(8)]
        [Required]
        public string UserName { get; set; } = default!;

        [MinLength(8)]
        [Required]
        public string PassWord { get; set; } = default!;

        [EmailAddress]
        public string Email { get; set; } = default!;

        [Phone]
        public string Phone { get; set; } =default!;
        public string Address { get;set; } =default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfJoing { get; set; } = default!;
        public bool IsAdmin { get; set; } = false;

        [ForeignKey(nameof(MeasurementId))]
        public int MeasurementId { get; set; }
        public MeasurementInformation Measurement { get; set; }= default!;

        public ICollection<Chat> ReceivedMessages { get; set; }=new Collection<Chat>();
        public ICollection<Chat> SentMessages { get; set; }=new Collection<Chat>();
        public ICollection<Notify> Notifies{ get; set; }=new Collection<Notify>();
        public ICollection<Task> Tasks{ get; set; }=new Collection<Task>();
        public ICollection<UserSample> User_Samples{ get; set; }=new Collection<UserSample>();
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(c => c.UserName).IsUnique(true);
            builder.HasIndex(c => c.PassWord).IsUnique(true);
            builder.HasMany(c => c.Notifies).WithOne(c => c.User).HasForeignKey(notify=>notify.UserId);
            builder.HasMany(c => c.Tasks).WithOne(c => c.User).HasForeignKey(task=>task.UserId);
            builder.HasMany(c => c.User_Samples).WithOne(c => c.User).HasForeignKey(sample=>sample.UserId);
        }
    }
}
