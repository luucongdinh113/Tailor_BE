using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.ImageProduct;
using Tailor_Infrastructure.Dto.InventoryCategory;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public class ImageProductRepository : GenericRepository<ImagesProduct, int>, IImageProductRepository
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly IMapper _mapper;
        public ImageProductRepository(TaiLorContext context, IUnitOfWork unitOfWorkRepository, IMapper mapper) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _mapper = mapper;
        }
        public ImagesProduct CreateImage(CreateImage createInput)
        {
            var image = _mapper.Map<ImagesProduct>(createInput);
            _unitOfWorkRepository.ImageProductRepository.Insert(image);
            return image;
        }

    }
}
