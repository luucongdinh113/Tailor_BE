using AutoMapper;
using MediatR;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateProductCommand : ICommand<ProductDto>
    {
        #region param
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public string Note { get; set; } = default!;
        public string NoteCloth { get; set; } = default!;
        public decimal PriceCloth { get; set; } = default!;
        #endregion
        public class CreateProductHanlderCommand : ICommandHandler<CreateProductCommand, ProductDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly  IMapper _mapper;
            public CreateProductHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var createProduct = _mapper.Map<CreateProduct>(request);
                return Task.FromResult(_unitOfWorkRepository.ProductRepository.CreateProduct(createProduct));
            }
        }
    }
}
