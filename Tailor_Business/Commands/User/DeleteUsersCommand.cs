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
    public class DeleteUsersCommand : ICommand<Unit>
    {
        #region parameter
        public List<Guid> Ids { get; set; } = new();
        #endregion
        public class DeleteUsersHandlerCommand : ICommandHandler<DeleteUsersCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteUsersHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.UserRepository.DeleteListAsync(request.Ids);
                return Unit.Value;
            }
        }
    }
}
