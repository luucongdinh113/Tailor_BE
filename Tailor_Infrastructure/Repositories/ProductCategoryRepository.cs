using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory, int>, IProductCategoryRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public ProductCategoryRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public void CreateProductCategory(CreateProductCategory createProductCategory)
        {
            var productCategory=_mapper.Map<ProductCategory>(createProductCategory);
            _unitOfWorkRepository.ProductCategoryRepository.Insert(productCategory);
        }
        public ProductCategoryDto UpdateProductCategory(UpdateProductCategory updateProductCategory)
        {
            var productCategory = _unitOfWorkRepository.ProductCategoryRepository.GetById(updateProductCategory.Id);
            Assign.Partial(updateProductCategory, productCategory);
            _unitOfWorkRepository.ProductCategoryRepository.Update(productCategory);
            return _mapper.Map<ProductCategoryDto>(productCategory);
        }
    }
}
