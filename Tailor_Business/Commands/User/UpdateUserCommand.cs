using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Common;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateUserCommand: ICommand<UserDto>
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
        public string? UserName { get; set; } = default!;
        public string? PassWord { get; set; } = default!;
        public double NeckCircumference { get; set; }
        public double CheckCircumference { get; set; }
        public double WaistCircumference { get; set; }
        public double ButtCircumference { get; set; }
        public double ShoulderWidth { get; set; }
        public double UnderarmCircumference { get; set; }
        public double SleeveLength { get; set; }
        public double CuffCircumference { get; set; }
        public double ShirtLength { get; set; }
        public double ThighCircumference { get; set; }
        public double BottomCircumference { get; set; }
        public double ArmCircumference { get; set; }
        public double PantLength { get; set; }
        public double KneeHeight { get; set; }
        public double PantLegWidth { get; set; }
        public string Avatar { get; set; } = default!;
        public DateTime BirthDay { get; set; } = default!;


        #endregion
        public class UpdateUserHandlerCommand : ICommandHandler<UpdateUserCommand, UserDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateUserHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                if (!String.IsNullOrEmpty(request.PassWord))
                {
                    if(request.PassWord.Length<8)
                    {
                        throw new Exception("Password must be greater than 8 characters");
                    }    
                    request.PassWord = PasswordHasher.HashPassword(request.PassWord);
                }
                var updateUser = _mapper.Map<UpdateUser>(request);
                return Task.FromResult(_unitOfWorkRepository.UserRepository.UpdateUser(updateUser)); 
            }
        }
    }
    public class UpdatePasswordForUserCommanddValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdatePasswordForUserCommanddValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        }
    }
}
