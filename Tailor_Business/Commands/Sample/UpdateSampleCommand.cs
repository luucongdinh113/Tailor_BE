using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.InventoryCategory;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.ProductCategory;
using Tailor_Infrastructure.Dto.Sample;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateSampleCommand : IRequest<SampleDto>
    {
        #region param
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public string Note { get; set; } = default!;

        #endregion
        public class UpdateSampleHandlerCommand : IRequestHandler<UpdateSampleCommand, SampleDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateSampleHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<SampleDto> Handle(UpdateSampleCommand request, CancellationToken cancellationToken)
            {
                _ = _unitOfWorkRepository.ProductCategoryRepository.GetById(request.ProductCategoryId);
                var updateSample = _mapper.Map<UpdateSample>(request);
                return await _unitOfWorkRepository.SampleRepository.UpdateSampleAsync(updateSample);
            }
        }
    }
}
