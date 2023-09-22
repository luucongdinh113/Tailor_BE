using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class DeleteUserCommand: ICommand<Unit>
    {
        #region parameter
        public Guid Id { get; set; }
        #endregion
        public class DeleteUserHandlerCommand : ICommandHandler<DeleteUserCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteUserHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.UserRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
