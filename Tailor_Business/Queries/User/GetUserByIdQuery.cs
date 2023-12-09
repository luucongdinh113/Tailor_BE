using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
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
            private readonly TaiLorContext _context;

            public GetUserByIdHandlerQuery(IUnitOfWork unitOfWork, IMapper mapper, TaiLorContext context)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _context = context;
            }

            public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)  
            {
                var result = await _context.Users.Include(c => c.Tasks).Include(c=>c.Notifies).Where(c => c.Id.Equals(request.Id)).Select(c => _mapper.Map<UserDto>(c)).FirstOrDefaultAsync();
                return result;
            }
        }
    }
}
