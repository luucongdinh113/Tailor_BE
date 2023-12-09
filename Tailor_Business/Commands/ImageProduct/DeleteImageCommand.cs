using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.ImageProduct;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.ImageProduct
{
    public class DeleteImageCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public class DeleteImageHandlerCommand : IRequestHandler<DeleteImageCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public DeleteImageHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.ImageProductRepository.DeleteAsync(request.Id);
                return true;
            }
        }
    }
}
