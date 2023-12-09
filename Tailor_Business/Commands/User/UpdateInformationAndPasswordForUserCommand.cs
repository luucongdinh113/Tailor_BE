using AutoMapper;
using FluentValidation;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Business.Commands.User
{
    public class UpdateInformationAndPasswordForUserCommand: ICommand<UserDto>
    {
        #region param
        public string? OldPassword { get; set; } = default!;
        public string? NewPassword { get; set; } = default!;
        public string? ConfirmPassword { get; set; } = default!;
        public string Avatar { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDay { get; set; } = default!;
        #endregion

        public class UpdatePasswordForUserHandlerCommand : ICommandHandler<UpdateInformationAndPasswordForUserCommand, UserDto>
        {
          private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedUserService _loggedUserService;
            private readonly IMapper _mapper;
            public UpdatePasswordForUserHandlerCommand(IUnitOfWork unitOfWork, ILoggedUserService loggedUserService,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _loggedUserService = loggedUserService;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(UpdateInformationAndPasswordForUserCommand request, CancellationToken cancellationToken)
            {
                var userName = _loggedUserService.UserName;
                var user = (await _unitOfWork.UserRepository.GetAsync(c => c.UserName == userName)).FirstOrDefault()
                    ?? throw new Exception("Token invalid");
                user.Avatar = request.Avatar;
                user.Email = request.Email;
                user.Phone = request.Phone;
                user.Address = request.Address;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.BirthDay = request.BirthDay;
                if (request.OldPassword != null && request.NewPassword!=null && request.ConfirmPassword!=null)
                {
                    if (request.NewPassword != request.ConfirmPassword) throw new Exception("NewPass not equal ConfirmPass");
                    if (!PasswordHasher.VerifyPassword(user.PassWord, request.OldPassword))
                        throw new Exception("OldPass InValid");
                    user.PassWord = PasswordHasher.HashPassword(request.NewPassword);
                }
                _unitOfWork.UserRepository.Update(user);
                return _mapper.Map<UserDto>(user);
            }
        }

    }
    public  class UpdatePasswordForUserCommandValidator : AbstractValidator<UpdateInformationAndPasswordForUserCommand>
    {
        public UpdatePasswordForUserCommandValidator()
        {
            RuleFor(x => x.NewPassword).Equal(c=>c.ConfirmPassword);
            RuleFor(c => c.NewPassword).MinimumLength(8);
        }
    }
}
