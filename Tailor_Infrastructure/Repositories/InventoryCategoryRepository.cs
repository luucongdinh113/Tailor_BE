using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class InventoryCategoryRepository : GenericRepository<InventoryCategory, int>, IInventoryCategoryRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public InventoryCategoryRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public void CreateInventoryCategory(CreateInventoryCategory createInventoryCategory)
        {
            var inventoryCategory = _mapper.Map<InventoryCategory>(createInventoryCategory);
            _unitOfWorkRepository.InventoryCategoryRepository.Insert(inventoryCategory);
        }
        public async Task<InventoryCategoryDto> UpdateInventoryCategoryAsync(UpdateInventoryCategory updateInventoryCategory)
        {
            var inventoryCategory = await _unitOfWorkRepository.InventoryCategoryRepository.GetByIdAsync(updateInventoryCategory.Id);
            Assign.Omit(updateInventoryCategory, inventoryCategory);
            await _unitOfWorkRepository.InventoryCategoryRepository.UpdateAsync(inventoryCategory);
            return _mapper.Map<InventoryCategoryDto>(inventoryCategory);
        }
    }
}
