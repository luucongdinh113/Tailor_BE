using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        public UserRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
    }
}
