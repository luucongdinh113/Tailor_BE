using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateUserCommand: IRequest<UserDto>
    {
        #region param
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfJoing { get; set; } = DateTime.Now;
        public bool? IsAdmin { get; set; } = false;
        public int? MeasurementId { get; set; }
        public string UserName { get; set; } = default!;
        public string PassWord { get; set; } = default!;

        #endregion
        public class UpdateUserHandlerCommand : IRequestHandler<UpdateUserCommand, UserDto>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateUserHandlerCommand(IUnitOfWorkRepository unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var updateUser = _mapper.Map<UpdateUser>(request);
                return _unitOfWorkRepository.UserRepository.UpdateUser(updateUser); 
            }
        }
    }
}
