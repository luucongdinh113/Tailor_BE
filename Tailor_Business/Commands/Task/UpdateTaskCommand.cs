using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateTaskCommand: ICommand<TaskDto>
    {
        #region param
        public int Id { get; set; }
        public Guid? UserId { get; set; }

        public int? SampleId { get; set; }

        public int? ProductId { get; set; }

        public string Content { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }

        #endregion
        public class UpdateTaskHandlerCommand : ICommandHandler<UpdateTaskCommand, TaskDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            public UpdateTaskHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
            }

            public Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
            {
                var updateTask = _mapper.Map<UpdateTask>(request);
                return Task.FromResult(_unitOfWorkRepository.TaskRepository.UpdateTask(updateTask));
            }
        }
    }
}
