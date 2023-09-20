using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class DeleteProductCategoryCommand : IRequest<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteProductCategoryHandlerCommand : IRequestHandler<DeleteProductCategoryCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteProductCategoryHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
            {
                _unitOfWorkRepository.ProductCategoryRepository.Delete(request.Id);
                return Unit.Value;
            }
        }
    }
}
