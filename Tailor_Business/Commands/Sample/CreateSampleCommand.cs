using AutoMapper;
using MediatR;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateSampleCommand : IRequest<Unit>
    {
        #region param
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public string Note { get; set; } = default!;
        #endregion
        public class CreateSamplHanlderCommand : IRequestHandler<CreateSampleCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly  IMapper _mapper;
            public CreateSamplHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateSampleCommand request, CancellationToken cancellationToken)
            {
                var createSample = _mapper.Map<CreateSample>(request);
                _=_unitOfWorkRepository.ProductCategoryRepository.GetById(request.ProductCategoryId);
                await _unitOfWorkRepository.SampleRepository.CreateSampleAsync(createSample);
                return Unit.Value;
            }
        }
    }
}
