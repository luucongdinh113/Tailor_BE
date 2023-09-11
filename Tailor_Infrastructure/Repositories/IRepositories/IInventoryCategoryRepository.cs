using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IInventoryCategoryRepository: IGenericRepository<InventoryCategory, int>
    {
    }
}
