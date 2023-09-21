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
    public class GetProductCategoryByIdQuery:IRequest<ProductCategoryDto>
    {
        #region param
        public int Id { get; set; }
        #endregion
        public class GetProductCategoryByIdHandlerQuery : IRequestHandler<GetProductCategoryByIdQuery, ProductCategoryDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public GetProductCategoryByIdHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<ProductCategoryDto> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var productCategory = await _unitOfWorkRepository.ProductCategoryRepository.GetByIdAsync(request.Id);
                return _mapper.Map<ProductCategoryDto>(productCategory);
            }
        }
    }
}
