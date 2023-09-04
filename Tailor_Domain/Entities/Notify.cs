using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Domain.Entities
{
    public class Notify: BaseEnity<int>
    {
        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        [ForeignKey(nameof(TaskId))]
        public int? TaskId { get; set; }
        public Task Task{ get; set; }= default!;

        public string Content { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string? LinkProduct { get; set; }
        public int Priority { get; set; }
        public bool IsRead { get; set; }
    }
}
