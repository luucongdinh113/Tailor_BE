using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.UserSample
{
    public class CreateUserSample
    {
        public Guid UserId { get; set; }
        public int SampleId { get; set; }
        public bool Liked { get; set; }
    }
}
