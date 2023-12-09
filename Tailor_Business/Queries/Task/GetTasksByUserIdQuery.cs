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
    public class GetTasksByUserIdQuery : IQuery<IEnumerable<TaskDto>>
    {
        public Guid UserId { get; set; }
        public class GetTasksByUserIdHandlerQuery : IQueryHandler<GetTasksByUserIdQuery, IEnumerable<TaskDto>>
        {
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetTasksByUserIdHandlerQuery(IMapper mapper, TaiLorContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<IEnumerable<TaskDto>> Handle(GetTasksByUserIdQuery request, CancellationToken cancellationToken)
            {
                var lists = await _context.Tasks.Include(c => c.Product).Include(c => c.Product.ImagesProducts).Include(c => c.Product.ProductCategory).Include(c => c.Sample).Where(c => c.UserId == request.UserId).Select(c => _mapper.Map<TaskDto>(c)).ToListAsync();
                var listDone = lists.Where(c => c.Status == "done").OrderByDescending(c => c.EndTime).ToList();
                var listComplete = lists.Where(c => c.Status == "complete").OrderByDescending(c => c.EndTime).ToList();
                var listTodo = lists.Where(c => c.Status =="todo").OrderByDescending(c => c.EndTime).ToList();
                var listDoing = lists.Where(c => c.Status =="doing").OrderByDescending(c => c.EndTime).ToList();
                listDone.AddRange(listComplete);
                listDoing.AddRange(listDone);
                listTodo.AddRange(listDoing);
                return listTodo;
            }
        }

    }
}
