using AutoMapper;
using MediatR;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateProductCategoryCommand : IRequest<Unit>
    {
        #region param
        public string Name { get; set; } = default!;
        #endregion
        public class CreateProductCategoryHanlderCommand : IRequestHandler<CreateProductCategoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private IMapper _mapper;
            public CreateProductCategoryHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var createProductCategory = _mapper.Map<CreateProductCategory>(request);
                _unitOfWorkRepository.ProductCategoryRepository.CreateProductCategory(createProductCategory);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
