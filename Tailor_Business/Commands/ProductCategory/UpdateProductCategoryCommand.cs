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
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateProductCategoryCommand : ICommand<ProductCategoryDto>
    {
        #region param
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        #endregion
        public class UpdateProductCategoryHandlerCommand : ICommandHandler<UpdateProductCategoryCommand, ProductCategoryDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateProductCategoryHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<ProductCategoryDto> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
            {
                var updateProductCategory = _mapper.Map<UpdateProductCategory>(request);
                return Task.FromResult(_unitOfWorkRepository.ProductCategoryRepository.UpdateProductCategory(updateProductCategory));
            }
        }
    }
}
