using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Task
{
    public class CreateTask
    {
        public Guid? UserId { get; set; }

        public int? SampleId { get; set; }

        public int? ProductId { get; set; }

        public string Content { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }
    }
}
