using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    public class User:BaseEnity<Guid>
    {
        [Column(TypeName = "nvarchar")]
        [MinLength(8)]
        [Required]
        public string UserName { get; set; } = default!;
        [Column(TypeName = "nvarchar")]
        [MinLength(8)]
        [Required]
        public string PassWord { get; set; } = default!;
        [EmailAddress]
        public string Email { get; set; } = default!;
        [Phone]
        public string Phone { get; set; } =default!;
        public DateTime DateOfJoing { get; set; } = default!;
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(c => c.UserName).IsUnique(true);
            builder.HasIndex(c => c.PassWord).IsUnique(true);
        }
    }
}
