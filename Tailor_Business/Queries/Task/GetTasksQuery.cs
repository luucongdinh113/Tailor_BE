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
    public class GetTasksQuery : IQuery<IEnumerable<TaskDto>>
    {
        public class GetTasksHandlerQuery : IQueryHandler<GetTasksQuery, IEnumerable<TaskDto>>
        {
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetTasksHandlerQuery(IMapper mapper, TaiLorContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<IEnumerable<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
            {
                var lists= await _context.Tasks.Include(c => c.User).Include(c => c.Product).Include(c => c.Sample).Select(c => _mapper.Map<TaskDto>(c)).ToListAsync();
                var listDone= lists.Where(c=>c.Status=="done" || c.Status=="complete").OrderByDescending(c=>c.EndTime).OrderBy(c => c.Index).ToList();
                var listDoing= lists.Where(c => c.Status != "done" && c.Status != "complete").OrderByDescending(c => c.EndTime).OrderBy(c => c.Index).ToList();
                listDoing.AddRange(listDone);
                return listDoing;
            }
        }

    }
}
