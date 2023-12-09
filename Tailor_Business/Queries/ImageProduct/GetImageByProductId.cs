using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Queries.ProductCategory;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.ImageProduct;
using Tailor_Infrastructure.Dto.Task;

namespace Tailor_Business.Queries.ImageProduct
{
    public class GetImageByProductIdQuery: IRequest<IEnumerable<ImageDto>>
    {
        public int ProductId { get; set; }
        public class GetImageByProductIdHandlerQuery: IRequestHandler<GetImageByProductIdQuery, IEnumerable<ImageDto>>
        {
            private readonly IMapper _mapper;
            private readonly TaiLorContext _context;
            public GetImageByProductIdHandlerQuery(IMapper mapper, TaiLorContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<IEnumerable<ImageDto>> Handle(GetImageByProductIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.ImagesProducts.Where(c=>c.ProductId==request.ProductId).Select(c => _mapper.Map<ImageDto>(c)).ToListAsync() ?? new List<ImageDto>();
            }
        }
    }
}
