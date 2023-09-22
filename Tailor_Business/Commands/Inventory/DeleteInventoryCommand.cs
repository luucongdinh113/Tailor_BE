using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class DeleteInventoryCommand : ICommand<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteInventoryHandlerCommand : ICommandHandler<DeleteInventoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteInventoryHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.InventoryRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
