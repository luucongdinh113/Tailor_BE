using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.UserSample
{
    public class UserSampleDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Tailor_Domain.Entities.User User { get; set; } = default!;

        public int SampleId { get; set; }
        public Tailor_Domain.Entities.Sample Sample { get; set; } = default!;

        public DateTimeOffset CreatedDate { get; set; }
        public bool Liked{ get; set; }
    }
}
