using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetAllProductCategoryQuery:IRequest<IEnumerable<ProductCategoryDto>>
    {
        public class GetAllProductCategoryHandlerQuery : IRequestHandler<GetAllProductCategoryQuery, IEnumerable<ProductCategoryDto>>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public GetAllProductCategoryHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
            {
                var productCategorys = await _unitOfWorkRepository.ProductCategoryRepository.GetAsync();
                return productCategorys.Select(c=>_mapper.Map<ProductCategoryDto>(c)).ToList();
            }
        }
    }
}
