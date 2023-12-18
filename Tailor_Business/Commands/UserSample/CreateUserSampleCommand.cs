using AutoMapper;
using MediatR;
using Tailor_Business.Commons;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.UserSample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateUserSampleCommand : ICommand<Unit>
    {
        #region param
        public Guid UserId { get; set; }
        public int SampleId { get; set; }
        #endregion
        public class CreateUserSampleHanlderCommand : ICommandHandler<CreateUserSampleCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly  IMapper _mapper;
            public CreateUserSampleHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateUserSampleCommand request, CancellationToken cancellationToken)
            {
                var sampleUsers = await _unitOfWorkRepository.UserSampleRepository.GetAsync(c => c.UserId.Equals(request.UserId) && c.SampleId.Equals(request.SampleId));
                if (sampleUsers.Count() == 0 || sampleUsers==null)
                {
                    var createUserSample = _mapper.Map<CreateUserSample>(request);
                    createUserSample.Liked = true;
                    _unitOfWorkRepository.UserSampleRepository.CreateUserSample(createUserSample);
                }
                else {
                    var sampleUser = (sampleUsers.ToArray())[0];
                    sampleUser.Liked = true;
                    _unitOfWorkRepository.UserSampleRepository.Update(sampleUser);
                }

                return Unit.Value;
            }
        }
    }
}
