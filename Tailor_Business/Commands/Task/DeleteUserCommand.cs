using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class DeleteTaskCommand:IRequest<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteTaskHandlerCommand : IRequestHandler<DeleteTaskCommand, Unit>
        {
            private readonly IUnitOfWorkRepository _unitOfWorkRepository;
            public DeleteTaskHandlerCommand(IUnitOfWorkRepository unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
            {
                _unitOfWorkRepository.TaskRepository.Delete(request.Id);
                return Unit.Value;
            }
        }
    }
}
