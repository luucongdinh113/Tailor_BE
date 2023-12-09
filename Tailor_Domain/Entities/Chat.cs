using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    public class Chat:BaseEnity<int>
    {
        [ForeignKey(nameof(ReceiverUserId))]
        public Guid ReceiverUserId { get; set; }
        public User ReceiverUser { get; set; } = default!;

        [ForeignKey(nameof(SenderUserId))]
        public Guid SenderUserId { get; set; }
        public User SenderUser { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string UpLoadFile { get; set; } = default!;
        public bool IsRead { get; set; } = false;
    }

    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasOne(c => c.SenderUser).WithMany(c => c.SentMessages).HasForeignKey(sender=>sender.SenderUserId);
            builder.HasOne(c => c.ReceiverUser).WithMany(c => c.ReceivedMessages).HasForeignKey(receiver=>receiver.ReceiverUserId);
            builder.HasQueryFilter(c => c.IsDeleted == false);
        }
    }
}
