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
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.UserSample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetUserSampleByUserQuery : IQuery<IEnumerable<UserSampleDto>>
    {
        public Guid UserId { get; set; }
        public class GetAllUserSampleHandlerQuery : IQueryHandler<GetUserSampleByUserQuery, IEnumerable<UserSampleDto>>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetAllUserSampleHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper,TaiLorContext context)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _context = context;
            }
            public async Task<IEnumerable<UserSampleDto>> Handle(GetUserSampleByUserQuery request, CancellationToken cancellationToken)
            {
                var userSamples = await _context.User_Samples.Include(c=>c.Sample).Include(c=>c.Sample.ProductCategory).Where(c=>c.UserId.Equals(request.UserId)).OrderByDescending(c=>c.CreatedDate).ToListAsync();
                return userSamples.Select(c=>_mapper.Map<UserSampleDto>(c)).ToList();
            }
        }
    }
}
