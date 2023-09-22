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
    public class DeleteProductCommand: ICommand<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteProductHandlerCommand : ICommandHandler<DeleteProductCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteProductHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.ProductRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
