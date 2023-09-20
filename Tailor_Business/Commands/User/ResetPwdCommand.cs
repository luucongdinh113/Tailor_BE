using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class ResetPwdCommand:IRequest<bool>
    {
        #region param
        public string UserName { get; set; } = default!;
        public string NewPassword { get; set; } = default!;
        public string ConfirmNewPassword { get; set; } = default!;
        #endregion
        public class ResetPwdHanlderCommand : IRequestHandler<ResetPwdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public ResetPwdHanlderCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<bool> Handle(ResetPwdCommand request, CancellationToken cancellationToken)
            {
                if (request.NewPassword != request.ConfirmNewPassword) throw new Exception("NewPassword must equal with ConfirmNewPassword");
                var user = _unitOfWorkRepository.UserRepository.Get(c => c.UserName == request.UserName).FirstOrDefault();
                if (user == null) throw new Exception($"User has username: {request.UserName} not found");
                if(user.OTP!=null)
                {
                    user.PassWord = PasswordHasher.HashPassword(request.NewPassword);
                    user.OTP = null;
                    _unitOfWorkRepository.UserRepository.Update(user);
                    await _unitOfWorkRepository.SaveChangesAsync();
                    return true;
                }
                throw new Exception("Error User not OTP");
            }
        }
    }
}
