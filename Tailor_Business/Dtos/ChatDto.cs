using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;

namespace Tailor_Business.Dtos
{
    public class ChatDto
    {
        public Guid ReceiverUserId { get; set; }
        public User ReceiverUser { get; set; } = default!;

        public Guid SenderUserId { get; set; }
        public User SenderUser { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string UpLoadFile { get; set; } = default!;
        public bool IsRead { get; set; }
    }
}
