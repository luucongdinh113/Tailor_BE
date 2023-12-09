using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Task
{
    public class TaskDto
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public Tailor_Domain.Entities.User? User {  get; set; }

        public int? SampleId { get; set; }
        public Tailor_Domain.Entities.Sample? Sample { get; set; }

        public int? ProductId { get; set; }
        public Tailor_Domain.Entities.Product? Product { get; set; }

        public string Content { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }
        public int Index { get; set; } = default!;
        public bool IsUseCloth { get; set; }
        public string Note { get; set; } = default!;
        public int Percent { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime? DoneDate { get; set; }


    }
}
