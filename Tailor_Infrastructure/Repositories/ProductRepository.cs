using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        private IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public ProductRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public void CreateProduct(CreateProduct createProduct)
        {
            var product=_mapper.Map<Product>(createProduct);
            _unitOfWorkRepository.ProductCategoryRepository.GetById(createProduct.ProductCategoryId);
            _unitOfWorkRepository.ProductRepository.Insert(product);
        }
        public ProductDto UpdateProduct(UpdateProduct updateProduct)
        {
            var product = _unitOfWorkRepository.ProductRepository.GetById(updateProduct.Id);
            _unitOfWorkRepository.ProductCategoryRepository.GetById(updateProduct.ProductCategoryId);
            Assign.Partial(updateProduct, product);
            _unitOfWorkRepository.ProductRepository.Update(product);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
