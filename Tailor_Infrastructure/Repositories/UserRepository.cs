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
            _unitOfWorkRepository.UserRepository.Insert(user);
        }

        public UserDto UpdateUser(UpdateUser userInput)
        {
            var user = _unitOfWorkRepository.UserRepository.GetById(userInput.Id);
            if(user.MeasurementId!=userInput.MeasurementId)
            {
                _unitOfWorkRepository.MeasurementInformationRepository.GetById(userInput.MeasurementId);
            }
            Assign.Partial(userInput, user);
            _unitOfWorkRepository.UserRepository.Update(user);
            return _mapper.Map<UserDto>(user);
        }
    }
}
