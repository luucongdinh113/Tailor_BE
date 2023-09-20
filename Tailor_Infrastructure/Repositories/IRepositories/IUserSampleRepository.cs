using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.UserSample;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IUserSampleRepository: IGenericRepository<UserSample, int>
    {
        void CreateUserSample(CreateUserSample createUserSample);
        UserSampleDto UpdateProduct(UpdateUserSample updateUserSample);
    }
}
