using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.User
{
    public class UpdateUser
    {
         public Guid Id { get; set; }
        public string Email { get; set; } = default!;

        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfJoing { get; set; } = default!;
        public bool IsAdmin { get; set; }

        public int MeasurementId { get; set; }
        public string UserName { get; set; } = default!;
        public string PassWord { get; set; } = default!;
    }
}
