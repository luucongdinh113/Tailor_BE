using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Dto.UserSample;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateUserSampleCommand : ICommand<UserSampleDto>
    {
        #region param
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int SampleId { get; set; }

        #endregion
        public class UpdateUserSampleHandlerCommand : ICommandHandler<UpdateUserSampleCommand, UserSampleDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateUserSampleHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<UserSampleDto> Handle(UpdateUserSampleCommand request, CancellationToken cancellationToken)
            {
                var updateUserSample = _mapper.Map<UpdateUserSample>(request);
                return Task.FromResult(_unitOfWorkRepository.UserSampleRepository.UpdateProduct(updateUserSample));
            }
        }
    }
}
