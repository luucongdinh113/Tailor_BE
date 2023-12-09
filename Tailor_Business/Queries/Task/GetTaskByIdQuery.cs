using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetTaskByIdQuery : IQuery<TaskDto>
    {
        public int Id { get; set; }
        public class GetTaskByIdHandlerQuery : IQueryHandler<GetTaskByIdQuery, TaskDto>
        {
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetTaskByIdHandlerQuery(IMapper mapper, TaiLorContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.Tasks.Include(c => c.Product).Include(c => c.Product.ProductCategory).Include(c => c.Product.ImagesProducts).Include(c => c.Sample).Include(c => c.User).Where(c => c.Id == request.Id).Select(c => _mapper.Map<TaskDto>(c)).FirstOrDefaultAsync() ?? new TaskDto() ;
            }
        }

    }
}
