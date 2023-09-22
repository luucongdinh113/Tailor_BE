using AutoMapper;
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
    public class GetUserByIdQuery : IQuery<UserDto>
    {
        #region parameter
        public Guid Id { get; set; }
        #endregion

        public class GetUserByIdHandlerQuery : IQueryHandler<GetUserByIdQuery, UserDto>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetUserByIdHandlerQuery(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)  
            {
                return Task.FromResult(_mapper.Map<UserDto>(_unitOfWork.UserRepository.GetById(request.Id)));
            }
        }
    }
}
