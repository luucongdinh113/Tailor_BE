using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.UserSample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class UserSampleRepository : GenericRepository<UserSample, int>, IUserSampleRepository
    {
        private IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public UserSampleRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }

        public void CreateUserSample(CreateUserSample createUserSample)
        {
            var userSample=_mapper.Map<UserSample>(createUserSample);
            _unitOfWorkRepository.UserSampleRepository.Insert(userSample);
        }

        public UserSampleDto UpdateProduct(UpdateUserSample updateUserSample)
        {
            var userSample = _unitOfWorkRepository.UserSampleRepository.GetById(updateUserSample.Id);
            _unitOfWorkRepository.UserRepository.GetById(updateUserSample.UserId);
            _unitOfWorkRepository.SampleRepository.GetById(updateUserSample.SampleId);
            userSample.UserId = updateUserSample.UserId;
            userSample.SampleId=updateUserSample.SampleId;
            _unitOfWorkRepository.UserSampleRepository.Update(userSample);
            return _mapper.Map<UserSampleDto>(userSample);
        }
    }
}
