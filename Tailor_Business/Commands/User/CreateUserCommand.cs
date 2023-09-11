using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.Chat;
using Tailor_Infrastructure.Dto.MeasurementInformation;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateUserCommand:IRequest<Unit>
    {
        #region param
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfJoing { get; set; } = DateTime.Now;
        public bool? IsAdmin { get; set; } = false;
        public int? MeasurementId { get; set; }
        #endregion
        public class CreateUserHanlderCommand : IRequestHandler<CreateUserCommand,Unit>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private IMapper _mapper;
            public CreateUserHanlderCommand(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }
            async Task<Unit> IRequestHandler<CreateUserCommand, Unit>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                using (var tr = await _unitOfWorkRepository.BeginTransactionAsync())
                {
                    try
                    {
                        var createUser = _mapper.Map<CreateUser>(request);
                        var idMeasurement = _unitOfWorkRepository.MeasurementInformationRepository.CreateMeasurement(new CreateMeasurementInformation());
                        createUser.MeasurementId = idMeasurement;
                        _unitOfWorkRepository.UserRepository.CreateUser(createUser);
                        await _unitOfWorkRepository.CommitTransactionAsync();
                        return Unit.Value;
                    }
                    catch
                    {
                        _unitOfWorkRepository.RollBack();
                        return Unit.Value;
                    }
                }
        }
        }
    }
}
