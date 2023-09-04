using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class UserSampleRepository : GenericRepository<UserSample, int>, IUserSampleRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        public UserSampleRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
    }
}
