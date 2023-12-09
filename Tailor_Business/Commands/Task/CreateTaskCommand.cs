using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class CreateTaskCommand : ICommand<TaskDto>
    {
        #region param
        public Guid? UserId { get; set; }

        public int? SampleId { get; set; }

        public int? ProductId { get; set; }

        public string Content { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }
        public int Index { get; set; } = default!;
        public bool IsUseCloth { get; set; }
        public string Note { get; set; } = default!;
        public int Percent { get; set; }
        #endregion
        public class CreateTaskHanlderCommand : ICommandHandler<CreateTaskCommand, TaskDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly TaiLorContext _context;
            private readonly  IMapper _mapper;
            public CreateTaskHanlderCommand(IUnitOfWork unitOfWorkRepository, TaiLorContext context, IMapper mapper)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
                _context = context;
            }

            public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
            {
                var createTask = _mapper.Map<CreateTask>(request);
                var maxIndex = 0;
                try
                {
                    maxIndex=await _context.Tasks.Select(c => c.Index).MaxAsync();
                }
                catch{ }
                createTask.Index = maxIndex+1;
                return _mapper.Map<TaskDto>(_unitOfWorkRepository.TaskRepository.CreateTask(createTask));
            }
        }
    }
}
