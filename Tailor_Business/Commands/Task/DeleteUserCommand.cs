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
    public class DeleteTaskCommand: ICommand<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteTaskHandlerCommand : ICommandHandler<DeleteTaskCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteTaskHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.TaskRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
