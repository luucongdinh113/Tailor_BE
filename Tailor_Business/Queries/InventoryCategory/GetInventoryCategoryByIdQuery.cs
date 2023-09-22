using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.ProductCategory
{
    public class GetInventoryCategoryByIdQuery : IQuery<InventoryCategoryDto>
    {
        #region param
        public int Id { get; set; }
        #endregion
        public class GetInventoryCategoryByIdHandlerQuery : IQueryHandler<GetInventoryCategoryByIdQuery, InventoryCategoryDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public GetInventoryCategoryByIdHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<InventoryCategoryDto> Handle(GetInventoryCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var inventoryCategory = await _unitOfWorkRepository.InventoryCategoryRepository.GetByIdAsync(request.Id);
                return _mapper.Map<InventoryCategoryDto>(inventoryCategory);
            }
        }
    }
}
