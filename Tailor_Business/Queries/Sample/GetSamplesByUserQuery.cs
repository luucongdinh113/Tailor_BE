using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetSamplesByUserQuery : IQuery<IEnumerable<SampleDto>>
    {
        public Guid UserId { get; set; }
        public class GetSamplesByUserQueryHandlerQuery : IQueryHandler<GetSamplesByUserQuery, IEnumerable<SampleDto>>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetSamplesByUserQueryHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper, TaiLorContext context)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _context = context;
            }

            public async Task<IEnumerable<SampleDto>> Handle(GetSamplesByUserQuery request, CancellationToken cancellationToken)
            {
                var listSampleIds = await _context.User_Samples.Where(c => request.UserId.Equals(c.UserId)).Select(c => c.SampleId).ToListAsync();

                var listSampleReturn = await _context.Samples.Include(c => c.ProductCategory).Where(c => listSampleIds.Contains(c.Id)).Select(c => _mapper.Map<SampleDto>(c)).ToListAsync();
                return listSampleReturn;
            }
        }
    }
}
