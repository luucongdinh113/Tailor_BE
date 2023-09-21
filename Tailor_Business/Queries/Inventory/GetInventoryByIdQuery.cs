using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Queries.Product
{
    public class GetInventoryByIdQuery : IRequest<InventoryDto>
    {
        #region param
        public int Id { get; set; }
        #endregion
        public class GetInventoryByIdHandlerQuery : IRequestHandler<GetInventoryByIdQuery, InventoryDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public GetInventoryByIdHandlerQuery(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _mapper = mapper;
                _unitOfWorkRepository = unitOfWorkRepository;
            }
            public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
            {
                var inventory = await _unitOfWorkRepository.InventoryRepository.GetByIdAsync(request.Id);
                return _mapper.Map<InventoryDto>(inventory);
            }
        }
    }
}
