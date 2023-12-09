using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.ImageProduct;
using Tailor_Infrastructure.Dto.Inventory;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IImageProductRepository:IGenericRepository<ImagesProduct, int>
    {
        ImagesProduct CreateImage(CreateImage createInput);
    }
}
