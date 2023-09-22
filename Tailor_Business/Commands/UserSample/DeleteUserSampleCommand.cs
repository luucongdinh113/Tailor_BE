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
    public class DeleteUserSampleCommand : ICommand<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteUserSampleHandlerCommand : ICommandHandler<DeleteUserSampleCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteUserSampleHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }


            public async Task<Unit> Handle(DeleteUserSampleCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.UserSampleRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
