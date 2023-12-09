using AutoMapper;
using MediatR;
using System.Windows.Input;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateInventoryCommand : ICommand<InventoryDto>
    {
        #region param
        public int Id { get; set; }
        public int InventoryCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Describe { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Used { get; set; }

        #endregion
        public class UpdateInventoryHandlerCommand : ICommandHandler<UpdateInventoryCommand, InventoryDto>
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
                return await _unitOfWorkRepository.InventoryRepository.UpdateInventoryAsync(updateInventory);
            }
        }
    }
}
