using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.User
{
    public class CheckOTPQuery: IRequest<bool>
    {
        public string OTP { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public class CheckOTPHandlerQuery : IRequestHandler<CheckOTPQuery, bool>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public CheckOTPHandlerQuery(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<bool> Handle(CheckOTPQuery request, CancellationToken cancellationToken)
            {
                var dateTimeNow = DateTime.UtcNow;
                var user = (await _unitOfWorkRepository.UserRepository.GetAsync(c => c.UserName == request.UserName)).FirstOrDefault();
                if (user == null) return false;
                if(user.OTP==request.OTP && DateTime.Compare(dateTimeNow,user.ExpiredOTP)<1)
                {
                    return true;
                }    
                return false;
            }
        }
    }
}
