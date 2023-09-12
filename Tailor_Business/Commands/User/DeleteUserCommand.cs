using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class DeleteUserCommand:IRequest<Unit>
    {
        #region parameter
        public Guid Id { get; set; }
        #endregion
        public class DeleteUserHandlerCommand : IRequestHandler<DeleteUserCommand, Unit>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            public DeleteUserHandlerCommand(IUnitOfWorkRepository unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                _unitOfWorkRepository.UserRepository.Delete(request.Id);
                return Unit.Value;
            }
        }
    }
}
