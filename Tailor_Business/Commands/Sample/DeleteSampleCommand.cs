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
    public class DeleteSampleCommand : ICommand<Unit>
    {
        #region parameter
        public int Id { get; set; }
        #endregion
        public class DeleteSampleHandlerCommand : ICommandHandler<DeleteSampleCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            public DeleteSampleHandlerCommand(IUnitOfWork unitOfWorkRepository)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
            }

            public async Task<Unit> Handle(DeleteSampleCommand request, CancellationToken cancellationToken)
            {
                await _unitOfWorkRepository.SampleRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}
