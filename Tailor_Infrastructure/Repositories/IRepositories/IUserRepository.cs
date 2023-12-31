﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Chat;
using Tailor_Infrastructure.Dto.User;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IUserRepository: IGenericRepository<User, Guid>
    {
        void CreateUser(CreateUser userInput);
        UserDto UpdateUser(UpdateUser userInput);
        Task<IEnumerable<UserDto>> GetAllAsync();
        bool CheckUserExist(string userName);
    }
}
