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
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Business.Commands.User
{
    public class UpdateStatusTaskCommand : ICommand<TaskDto>
    {
        #region param
        public int Id { get; set; }
        public string Status { get; set; } = default!;

        #endregion
        public class UpdateStatusTaskHandlerCommand : ICommandHandler<UpdateStatusTaskCommand, TaskDto>
        {
            private readonly TaiLorContext _context;
            private readonly IMapper _mapper;
            private readonly ICreateNotify _createNotify;
            public UpdateStatusTaskHandlerCommand(TaiLorContext context, IMapper mapper, ICreateNotify createNotify)
            {
                _mapper = mapper;
                _context = context;
                _createNotify= createNotify;
            }

            public async Task<TaskDto> Handle(UpdateStatusTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.Tasks.Include(c=>c.Product).Where(c => c.Id == request.Id).FirstOrDefaultAsync() ??
                    throw new Exception($"Not found object Task has Id = {request.Id}");
                if (task.Status != request.Status)
                {
                    await _createNotify.CreateNotifyAsync(task, request.Status, null);
                }
                task.Status = request.Status;
                if (request.Status == "complete")
                {
                    task.CompleteDate = DateTime.UtcNow;
                    task.Percent = 100;
                }
                else if (request.Status == "done")
                {
                    task.DoneDate = DateTime.UtcNow;
                    task.Percent = 100;
                }
                else if (request.Status == "todo") task.Percent = 0;

                _context.Update(task);
                await _context.SaveChangesAsync();
                return _mapper.Map<TaskDto>(task);
            }
        }
    }
}
