using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Notify
{
    public class UpdateNotify
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int? TaskId { get; set; }
        public string Content { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string? LinkProduct { get; set; }
        public int Priority { get; set; }
        public bool IsRead { get; set; }
    }
}
