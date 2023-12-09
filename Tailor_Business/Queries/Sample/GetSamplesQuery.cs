using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetSamplesQuery : IQuery<IEnumerable<SampleDto>>
    {
        public class GetSamplesHandlerQuery : IQueryHandler<GetSamplesQuery, IEnumerable<SampleDto>>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetSamplesHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper, TaiLorContext context)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _context = context;
            }

            public async Task<IEnumerable<SampleDto>> Handle(GetSamplesQuery request, CancellationToken cancellationToken)
            {
                var listSampleReturn = await _context.Samples.Include(c => c.ProductCategory).OrderByDescending(c => c.UpdatedDate).Select(c => _mapper.Map<SampleDto>(c)).ToListAsync();
                return listSampleReturn;
            }
        }
    }
}
