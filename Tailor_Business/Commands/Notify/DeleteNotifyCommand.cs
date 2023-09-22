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
    public class DeleteNotifyCommand: ICommand<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteNotifyHandlerCommand : ICommandHandler<DeleteNotifyCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteNotifyHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteNotifyCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.NotifyRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
