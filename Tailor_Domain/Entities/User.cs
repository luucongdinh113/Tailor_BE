using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Tailor_Domain.Entities
{
    public class User : BaseEnity<Guid>
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
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfJoing { get; set; } = default!;
        public DateTime BirthDay { get; set; } = default!;
        public bool IsAdmin { get; set; } = false;
        public double NeckCircumference { get; set; }
        public double CheckCircumference { get; set; }
        public double WaistCircumference { get; set; }
        public double ButtCircumference { get; set; }
        public double ShoulderWidth { get; set; }
        public double UnderarmCircumference { get; set; }
        public double SleeveLength { get; set; }
        public double CuffCircumference { get; set; }
        public double ShirtLength { get; set; }
        public double ThighCircumference { get; set; }
        public double BottomCircumference { get; set; }
        public double ArmCircumference { get; set; }
        public double PantLength { get; set; }
        public double KneeHeight { get; set; }
        public double PantLegWidth { get; set; }
        public string? OTP { get; set; } = default!;
        public string Avatar { get; set; } = default!;
        public DateTime ExpiredOTP{ get;set;}

        public List<Chat> ReceivedMessages { get; set; }=new List<Chat>();
        public List<Chat> SentMessages { get; set; }=new List<Chat>();
        public List<Notify> Notifies{ get; set; }=new List<Notify>();
        public List<Task> Tasks{ get; set; }=new List<Task>();
        public List<UserSample> User_Samples{ get; set; }=new List<UserSample>();
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(c => c.UserName).IsUnique(true);
            builder.HasMany(c => c.Notifies).WithOne(c => c.User).HasForeignKey(notify=>notify.UserId);
            builder.HasMany(c => c.Tasks).WithOne(c => c.User).HasForeignKey(task=>task.UserId);
            builder.HasMany(c => c.User_Samples).WithOne(c => c.User).HasForeignKey(sample=>sample.UserId);
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
