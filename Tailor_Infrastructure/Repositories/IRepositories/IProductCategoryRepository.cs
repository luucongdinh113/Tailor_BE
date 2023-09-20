using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.ProductCategory;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IProductCategoryRepository: IGenericRepository<ProductCategory, int>
    {
        void CreateProductCategory(CreateProductCategory createProductCategory);
        ProductCategoryDto UpdateProductCategory(UpdateProductCategory updateProductCategory);
    }
}
