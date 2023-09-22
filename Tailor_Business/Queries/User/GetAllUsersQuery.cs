using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.User
{
    public class GetAllUsersQuery: IQuery<IEnumerable<UserDto>>
    {
        #region parameter
        #endregion

        public class GetAllUsersHandlerQuery : IQueryHandler<GetAllUsersQuery, IEnumerable<UserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAllUsersHandlerQuery(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return await _unitOfWork.UserRepository.GetAllAsync();
            }
        }
    }
}
