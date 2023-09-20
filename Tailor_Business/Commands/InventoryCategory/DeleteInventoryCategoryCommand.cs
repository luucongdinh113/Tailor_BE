using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class DeleteInventoryCategoryCommand : IRequest<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteInventoryCategoryHandlerCommand : IRequestHandler<DeleteInventoryCategoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteInventoryCategoryHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteInventoryCategoryCommand request, CancellationToken cancellationToken)
            {
                _unitOfWorkRepository.InventoryCategoryRepository.Delete(request.Id);
                return Unit.Value;
            }
        }
    }
}
