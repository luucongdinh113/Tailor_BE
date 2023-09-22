using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateInventoryCategoryCommand : ICommand<InventoryCategoryDto>
    {
        #region param
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        #endregion
        public class UpdateInventoryCategoryHandlerCommand : ICommandHandler<UpdateInventoryCategoryCommand, InventoryCategoryDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateInventoryCategoryHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<InventoryCategoryDto> Handle(UpdateInventoryCategoryCommand request, CancellationToken cancellationToken)
            {
                var updateInventoryCategory = _mapper.Map<UpdateInventoryCategory>(request);
                return await _unitOfWorkRepository.InventoryCategoryRepository.UpdateInventoryCategoryAsync(updateInventoryCategory);
            }
        }
    }
}
