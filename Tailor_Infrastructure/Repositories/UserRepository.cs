using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public UserRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public void CreateUser(CreateUser userInput)
        {
            var user = _mapper.Map<User>(userInput);
            user.UserName = user.Phone;
            user.PassWord = user.Phone;
            _unitOfWorkRepository.UserRepository.Insert(user);
        }
    }
}
