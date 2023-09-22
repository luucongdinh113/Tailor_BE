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
    public class DeleteInventoryCategoryCommand : ICommand<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteInventoryCategoryHandlerCommand : ICommandHandler<DeleteInventoryCategoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteInventoryCategoryHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteInventoryCategoryCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.InventoryCategoryRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
