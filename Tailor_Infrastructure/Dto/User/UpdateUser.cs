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
        public double NeckCircumference { get; set; }
        public double CheckCircumference { get; set; }
        public double WaistCircumference { get; set; }
        public double ButtCircumference { get; set; }
        public double ShoulderWidth { get; set; }
        public double UnderarmCircumference { get; set; }
        public double SleeveLength { get; set; }
        public double CuffCircumference { get; set; }
        public double ShirtLength { get; set; }
        public double ThighCircumference { get; set; }
        public double BottomCircumference { get; set; }
        public double ArmCircumference { get; set; }
        public double PantLength { get; set; }
        public double KneeHeight { get; set; }
        public double PantLegWidth { get; set; }
        public string UserName { get; set; } = default!;
        public string PassWord { get; set; } = default!;
        public string Avatar { get; set; } = default!;
        public DateTime BirthDay { get; set; } = default!;

    }
}
