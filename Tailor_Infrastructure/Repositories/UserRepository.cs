using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        private readonly TaiLorContext _context;
        public UserRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _context = context;
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public void CreateUser(CreateUser userInput)
        {
            var user = _mapper.Map<User>(userInput);
            _unitOfWorkRepository.UserRepository.Insert(user);
        }

        public bool CheckUserExist(string phoneNumber)
        {
            return _context.Users.Any(c => c.Phone == phoneNumber);
        }
        public UserDto UpdateUser(UpdateUser userInput)
        {
            var user = _unitOfWorkRepository.UserRepository.GetById(userInput.Id);
            Assign.Partial(userInput, user);
            _unitOfWorkRepository.UserRepository.Update(user);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWorkRepository.UserRepository.GetAsync();
            var result = new List<UserDto>();
            foreach (var item in users)
            {
                result.Add(_mapper.Map<UserDto>(item));
            }
            return result;
        }
    }
}
