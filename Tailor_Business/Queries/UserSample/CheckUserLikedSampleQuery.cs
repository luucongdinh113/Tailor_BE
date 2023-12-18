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
    public class CheckUserLikedSampleQuery : IQuery<bool>
    {
        public Guid UserId { get; set; }
        public int SampleId{ get; set; }
        public class CheckUserLikedSampleHandlerQuery : IQueryHandler<CheckUserLikedSampleQuery, bool>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public CheckUserLikedSampleHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper,TaiLorContext context)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _context = context;
            }
            public async Task<bool> Handle(CheckUserLikedSampleQuery request, CancellationToken cancellationToken)
            {
                return await _context.User_Samples.AnyAsync(c => c.UserId.Equals(request.UserId) && c.SampleId.Equals(request.SampleId) && c.Liked);
            }
        }
    }
}
