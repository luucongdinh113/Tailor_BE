using AutoMapper;
using MediatR;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateInventoryCategoryCommand : IRequest<Unit>
    {
        #region param
        public string Name { get; set; } = default!;
        #endregion
        public class CreateInventoryCategoryHanlderCommand : IRequestHandler<CreateInventoryCategoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly  IMapper _mapper;
            public CreateInventoryCategoryHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(CreateInventoryCategoryCommand request, CancellationToken cancellationToken)
            {
                var createInventoryCategory = _mapper.Map<CreateInventoryCategory>(request);
                _unitOfWorkRepository.InventoryCategoryRepository.CreateInventoryCategory(createInventoryCategory);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
