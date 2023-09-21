using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.InventoryCategory;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IInventoryCategoryRepository: IGenericRepository<InventoryCategory, int>
    {
        void CreateInventoryCategory(CreateInventoryCategory createInventoryCategory);
        Task<InventoryCategoryDto> UpdateInventoryCategoryAsync(UpdateInventoryCategory updateInventoryCategory);
    }
}
