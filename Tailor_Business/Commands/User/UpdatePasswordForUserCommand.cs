using MediatR;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Repositories.IRepositories;
using Tailor_Infrastructure.Services;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Business.Commands.User
{
    public class UpdatePasswordForUserCommand: IRequest<bool>
    {
        #region param
        public string OldPassword { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;

        #endregion

        public class UpdatePasswordForUserHandlerCommand : IRequestHandler<UpdatePasswordForUserCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedUserService _loggedUserService;
            public UpdatePasswordForUserHandlerCommand(IUnitOfWork unitOfWork, ILoggedUserService loggedUserService)
            {
                _unitOfWork = unitOfWork;
                _loggedUserService = loggedUserService;
            }

            public async Task<bool> Handle(UpdatePasswordForUserCommand request, CancellationToken cancellationToken)
            {
                if (request.NewPassword != request.ConfirmPassword) throw new Exception("NewPass not equal ConfirmPass");
                var userName = _loggedUserService.UserName;
                var user = (await _unitOfWork.UserRepository.GetAsync(c => c.UserName == userName)).FirstOrDefault()
                    ?? throw new Exception("Token invalid");
                if (!PasswordHasher.VerifyPassword(user.PassWord, request.OldPassword))
                    throw new Exception("OldPass InValid");
                user.PassWord = PasswordHasher.HashPassword(request.NewPassword);
                _unitOfWork.UserRepository.Update(user);
                return true;
            }
        }
    }
}
