using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateProductCommand: ICommand<ProductDto>
    {
        #region param
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public string Note { get; set; } = default!;

        #endregion
        public class UpdateProductHandlerCommand : ICommandHandler<UpdateProductCommand, ProductDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateProductHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var updateProduct = _mapper.Map<UpdateProduct>(request);
                return Task.FromResult(_unitOfWorkRepository.ProductRepository.UpdateProduct(updateProduct));
            }
        }
    }
}
