using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Product;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IProductRepository: IGenericRepository<Product, int>
    {
        ProductDto CreateProduct(CreateProduct createProduct);
        ProductDto UpdateProduct(UpdateProduct updateProduct);
    }
}
