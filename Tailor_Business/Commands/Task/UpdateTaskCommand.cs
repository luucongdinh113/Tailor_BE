using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Domain.Entities;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;
using Tailor_Infrastructure.Services.IServices;

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
        public int Index { get; set; } = default!;
        public bool IsUseCloth { get; set; }
        public string Note { get; set; } = default!;
        public int Percent { get; set; }

        #endregion
        public class UpdateTaskHandlerCommand : ICommandHandler<UpdateTaskCommand, TaskDto>
        {
            private readonly IUnitOfWork _unitOfWorkRepository;
            private readonly IMapper _mapper;
            private readonly ICreateNotify _createNotify;
            private readonly TaiLorContext _context;
            public UpdateTaskHandlerCommand(IUnitOfWork unitOfWorkRepository, IMapper mapper, ICreateNotify createNotify, TaiLorContext context)
            {
                _unitOfWorkRepository = unitOfWorkRepository;
                _mapper = mapper;
                _createNotify = createNotify;
                _context = context;
            }

            public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
            {
                var updateTask = _mapper.Map<UpdateTask>(request);
                var task = await _context.Tasks.Include(c => c.Product).Where(c => c.Id == request.Id).FirstOrDefaultAsync() ??
                                    throw new Exception($"Not found object Task has Id = {request.Id}");
                if (task.Status != request.Status)
                {
                    await _createNotify.CreateNotifyAsync(task, request.Status, null);
                }
                else if (task.Percent != request.Percent)
                {
                    await _createNotify.CreateNotifyAsync(task, "", request.Percent);
                }
                if (request.Status == "complete")
                {
                    updateTask.CompleteDate = DateTime.UtcNow;
                    updateTask.Percent = 100;
                }
                else if (request.Status == "done")
                {
                    updateTask.DoneDate = DateTime.UtcNow;
                    updateTask.Percent = 100;
                }
                else if (request.Status == "todo") updateTask.Percent = 0;

                if (request.Percent == 100 && request.Status != "complete")
                {
                    await _createNotify.CreateNotifyAsync(task, request.Status, null);
                    updateTask.Status = "done";
                }
                return _unitOfWorkRepository.TaskRepository.UpdateTask(updateTask);
            }
        }
    }
}
