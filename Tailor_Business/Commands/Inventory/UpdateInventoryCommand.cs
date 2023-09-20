using AutoMapper;
using MediatR;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateInventoryCommand : IRequest<InventoryDto>
    {
        #region param
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Describe { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }

        #endregion
        public class UpdateInventoryHandlerCommand : IRequestHandler<UpdateInventoryCommand, InventoryDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateInventoryHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<InventoryDto> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
            {
                var updateInventory = _mapper.Map<UpdateInventory>(request);
                return _unitOfWorkRepository.InventoryRepository.UpdateInventory(updateInventory);
            }
        }
    }
}
