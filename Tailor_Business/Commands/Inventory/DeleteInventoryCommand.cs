using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class DeleteInventoryCommand : IRequest<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteInventoryHandlerCommand : IRequestHandler<DeleteInventoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteInventoryHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
            {
                _unitOfWorkRepository.InventoryRepository.Delete(request.Id);
                return Unit.Value;
            }
        }
    }
}
