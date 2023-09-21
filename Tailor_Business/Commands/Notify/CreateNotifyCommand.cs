using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateNotifyCommand : IRequest<Unit>
    {
        #region param
        public Guid UserId { get; set; }
        public int? TaskId { get; set; }
        public string Content { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string? LinkProduct { get; set; }
        public int Priority { get; set; }
        public bool IsRead { get; set; }
        #endregion
        public class CreateNotifyHanlderCommand : IRequestHandler<CreateNotifyCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly  IMapper _mapper;
            public CreateNotifyHanlderCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<Unit> Handle(CreateNotifyCommand request, CancellationToken cancellationToken)
            {
                var createProduct = _mapper.Map<CreateProduct>(request);
                _unitOfWorkRepository.ProductRepository.CreateProduct(createProduct);
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
