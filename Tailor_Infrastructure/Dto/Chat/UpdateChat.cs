using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Chat
{
    public class UpdateChat
    {
        public int Id { get; set; }
        public Guid ReceiverUserId { get; set; }
        public Guid SenderUserId { get; set; }
        public string Content { get; set; } = default!;
        public string UpLoadFile { get; set; } = default!;
    }
}
