﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.UserSample
{
    public class UpdateUserSample
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int SampleId { get; set; }
    }
}
