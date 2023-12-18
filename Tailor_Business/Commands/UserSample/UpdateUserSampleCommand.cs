using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Dto.UserSample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateUserSampleCommand : ICommand<Unit>
    {
        #region param
        public Guid UserId { get; set; }
        public int SampleId { get; set; }
        public bool Liked { get; set; }

        #endregion
        public class UpdateUserSampleHandlerCommand : ICommandHandler<UpdateUserSampleCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateUserSampleHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(UpdateUserSampleCommand request, CancellationToken cancellationToken)
            {
                var updateUserSample = _mapper.Map<UpdateUserSample>(request);
                var sampleUsers = _unitOfWorkRepository.UserSampleRepository.Get(c => c.UserId.Equals(request.UserId) && c.SampleId.Equals(request.SampleId));
                if (sampleUsers.Count() == 0 || sampleUsers == null)
                {
                    var createUserSample = _mapper.Map<CreateUserSample>(request);
                    createUserSample.Liked = request.Liked;
                    _unitOfWorkRepository.UserSampleRepository.CreateUserSample(createUserSample);
                }
                else
                {
                    var sampleUser = (sampleUsers.ToArray())[0];
                    sampleUser.Liked = request.Liked;
                    _unitOfWorkRepository.UserSampleRepository.Update(sampleUser);
                }
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
