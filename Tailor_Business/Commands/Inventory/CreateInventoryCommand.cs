using AutoMapper;
using MediatR;
using System.Windows.Input;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateInventoryCommand : ICommand<Unit>
    {
        #region param
        public int InventoryCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Describe { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        #endregion
        public class CreateInventoryCommandHanlderCommand : ICommandHandler<CreateInventoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly  IMapper _mapper;
            public CreateInventoryCommandHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
            {
                var createInventory = _mapper.Map<CreateInventory>(request);
                _unitOfWorkRepository.InventoryRepository.CreateInventory(createInventory);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
