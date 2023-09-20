using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateNotifyCommand : IRequest<ProductDto>
    {
        #region param
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int? TaskId { get; set; }
        public string Content { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string? LinkProduct { get; set; }
        public int Priority { get; set; }
        public bool IsRead { get; set; }

        #endregion
        public class UpdateNotifyHandlerCommand : IRequestHandler<UpdateNotifyCommand, ProductDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateNotifyHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(UpdateNotifyCommand request, CancellationToken cancellationToken)
            {
                var updateProduct = _mapper.Map<UpdateProduct>(request);
                return _unitOfWorkRepository.ProductRepository.UpdateProduct(updateProduct);
            }
        }
    }
}
