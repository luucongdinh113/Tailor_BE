using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Inventory;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IInventoryRepository: IGenericRepository<Inventory, int>
    {
        void CreateInventory(CreateInventory createInventory);
        InventoryDto UpdateInventory(UpdateInventory updateInventory);
    }
}
