using AutoMapper;
using MediatR;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.UserSample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateUserSampleCommand : IRequest<Unit>
    {
        #region param
        public Guid UserId { get; set; }
        public int SampleId { get; set; }
        #endregion
        public class CreateUserSampleHanlderCommand : IRequestHandler<CreateUserSampleCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private IMapper _mapper;
            public CreateUserSampleHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(CreateUserSampleCommand request, CancellationToken cancellationToken)
            {
                var createUserSample = _mapper.Map<CreateUserSample>(request);
                _unitOfWorkRepository.UserSampleRepository.CreateUserSample(createUserSample);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
