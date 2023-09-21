using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetAllInventoryCategoryQuery:IRequest<IEnumerable<InventoryCategoryDto>>
    {
        public class GetAllProductCategoryHandlerQuery : IRequestHandler<GetAllInventoryCategoryQuery, IEnumerable<InventoryCategoryDto>>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public GetAllProductCategoryHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<IEnumerable<InventoryCategoryDto>> Handle(GetAllInventoryCategoryQuery request, CancellationToken cancellationToken)
            {
                var inventoryCategorys = await _unitOfWorkRepository.InventoryCategoryRepository.GetAsync();
                return inventoryCategorys.Select(c=>_mapper.Map<InventoryCategoryDto>(c)).ToList();
            }
        }
    }
}
