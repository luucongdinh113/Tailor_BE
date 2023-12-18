using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Notify
{
    public class NotifyDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Tailor_Domain.Entities.User User { get; set; } = default!;
        public int? TaskId { get; set; }
        public Tailor_Domain.Entities.Task Task { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string? LinkProduct { get; set; }
        public int Priority { get; set; }
        public bool IsRead { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
