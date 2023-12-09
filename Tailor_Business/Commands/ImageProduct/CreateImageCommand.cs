using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.ImageProduct;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.ImageProduct
{
    public class CreateImageCommand: IRequest<ImageDto>
    {
        public int ProductId { get; set; }
        public string LinkImage { get; set; } = default!;
        public class CreateImageHandlerCommand : IRequestHandler<CreateImageCommand, ImageDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public CreateImageHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<ImageDto> Handle(CreateImageCommand request, CancellationToken cancellationToken)
            {
                var image = _mapper.Map<CreateImage>(request);
                var check = await _unitOfWorkRepository.ProductRepository.GetByIdAsync(request.ProductId);
                
                return _mapper.Map<ImageDto>(_unitOfWorkRepository.ImageProductRepository.CreateImage(image));
            }
        }
    }
}
