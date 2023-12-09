using AutoMapper;
using FluentValidation;
using MediatR;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateUserCommand: ICommand<Unit>
    {
        #region param
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfJoing { get; set; } = DateTime.Now;
        public bool? IsAdmin { get; set; } = false;
        public double NeckCircumference { get; set; }
        public double CheckCircumference { get; set; }
        public double WaistCircumference { get; set; }
        public double ButtCircumference { get; set; }
        public double ShoulderWidth { get; set; }
        public double UnderarmCircumference { get; set; }
        public double SleeveLength { get; set; }
        public double CuffCircumference { get; set; }
        public double ShirtLength { get; set; }
        public double ThighCircumference { get; set; }
        public double BottomCircumference { get; set; }
        public double ArmCircumference { get; set; }
        public double PantLength { get; set; }
        public double KneeHeight { get; set; }
        public double PantLegWidth { get; set; }
        public string Avatar { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string PassWord { get; set; } = default!;
        public DateTime BirthDay { get; set; } = default!;
        #endregion
        public class CreateUserHanlderCommand : ICommandHandler<CreateUserCommand,Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly  IMapper _mapper;
            public CreateUserHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }
            async Task<Unit> IRequestHandler<CreateUserCommand, Unit>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                using var tr = await _unitOfWorkRepository.BeginTransactionAsync(cancellationToken);
                try
                {
                    if (_unitOfWorkRepository.UserRepository.CheckUserExist(request.Phone))
                        throw new Exception($"User has phone {request.Phone} in DB");
                    request.DateOfJoing = DateTime.UtcNow;
                    request.UserName= request.UserName==""?request.Phone:request.UserName;
                    request.PassWord = request.PassWord == ""?request.Phone:request.PassWord;
                    request.PassWord = PasswordHasher.HashPassword(request.PassWord);
                    var createUser = _mapper.Map<CreateUser>(request);
                    _unitOfWorkRepository.UserRepository.CreateUser(createUser);
                    await _unitOfWorkRepository.CommitTransactionAsync(cancellationToken);
                    return Unit.Value;
                }
                catch
                {
                    _unitOfWorkRepository.RollBack(cancellationToken);
                    return Unit.Value;
                }
            }
        }
    }
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.PassWord).NotEmpty().MinimumLength(8);
        }
    }
}
