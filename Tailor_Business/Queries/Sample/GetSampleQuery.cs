using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetSampleQuery : IQuery<SampleDto>
    {
        public int Id { get; set; }
        public class GetSampleHandlerQuery : IQueryHandler<GetSampleQuery, SampleDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetSampleHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper, TaiLorContext context)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
                _context = context;
            }

            public async Task<SampleDto> Handle(GetSampleQuery request, CancellationToken cancellationToken)
            {
                return await _context.Samples.Include(c => c.ProductCategory).Where(c=>c.Id.Equals(request.Id)).Select(c => _mapper.Map<SampleDto>(c)).FirstOrDefaultAsync();
            }
        }
    }
}
