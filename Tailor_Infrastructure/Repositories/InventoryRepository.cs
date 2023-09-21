using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Inventory;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class InventoryRepository : GenericRepository<Inventory, int>, IInventoryRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public InventoryRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public void CreateInventory(CreateInventory createInventory)
        {
            var inventory = _mapper.Map<Inventory>(createInventory);
            _unitOfWorkRepository.InventoryRepository.Insert(inventory);
        }
        public async Task<InventoryDto> UpdateInventoryAsync(UpdateInventory updateInventory)
        {
            var inventory = await _unitOfWorkRepository.InventoryRepository.GetByIdAsync(updateInventory.Id);
            _unitOfWorkRepository.InventoryCategoryRepository.GetById(updateInventory.InventoryCategoryId);
            Common.Assign.Partial(updateInventory, inventory);
            await _unitOfWorkRepository.InventoryRepository.UpdateAsync(inventory);
            return _mapper.Map<InventoryDto>(inventory);
        }
    }
}
