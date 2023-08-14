﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Services.IServices
{
    public interface IJWTService
    {
        Task<string> GenerateJSONWebToken(UserModel userInfo);
    }
}
