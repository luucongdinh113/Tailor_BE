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
    public class Chat:BaseEnity<int>
    {
        [ForeignKey(nameof(ReceiverUserId))]
        public Guid ReceiverUserId { get; set; }
        public User ReceiverUser { get; set; } 

        [ForeignKey(nameof(SenderUserId))]
        public Guid SenderUserId { get; set; }
        public User SenderUser { get; set; } 
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
        }
    }
}
