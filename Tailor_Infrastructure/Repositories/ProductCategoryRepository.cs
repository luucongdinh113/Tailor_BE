using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory, int>, IProductCategoryRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public ProductCategoryRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
    }
}
