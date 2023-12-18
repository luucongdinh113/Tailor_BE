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
    public class UpdateInfoTaskCommand : ICommand<TaskDto>
    {
        #region param
        public int Id { get; set; }
        public string Content { get; set; } = default!;
        public bool IsUseCloth { get; set; }
        public string Note { get; set; } = default!;
        public string Status { get; set; } = default!;
        public int Percent { get; set; }
        #endregion
        public class UpdateInfoTaskHandlerCommand : ICommandHandler<UpdateInfoTaskCommand, TaskDto>
        {
            private readonly TaiLorContext _context;
            private readonly IMapper _mapper;
            private readonly ICreateNotify _createNotify;
            public UpdateInfoTaskHandlerCommand(TaiLorContext context, IMapper mapper, ICreateNotify createNotify)
            {
                _mapper = mapper;
                _context = context;
                _createNotify = createNotify;
            }

            public async Task<TaskDto> Handle(UpdateInfoTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.Tasks.Include(c=>c.Product).Where(c => c.Id == request.Id).FirstOrDefaultAsync() ??
                    throw new Exception($"Not found object Task has Id = {request.Id}");
                if(task.Status!=request.Status)
                {
                    await _createNotify.CreateNotifyAsync(task, request.Status, null);
                }
                else if(task.Percent!=request.Percent)
                {
                    await _createNotify.CreateNotifyAsync(task, "", request.Percent);
                }    
                task.IsUseCloth = request.IsUseCloth;
                task.Content = request.Content;
                task.Note = request.Note;
                task.Status = request.Status;
                task.Percent = request.Percent;
                if (request.Status == "complete")
                {
                    task.CompleteDate = DateTime.UtcNow;
                    task.Percent = 100;
                }
                else if(request.Status == "done")
                {
                    task.DoneDate = DateTime.UtcNow;
                    task.Percent = 100;
                }
                else if (request.Status == "todo") task.Percent = 0;

                if (request.Percent == 100 && request.Status!="complete" && request.Status != "done") task.Percent = 75;
                if (request.Percent == 100 && request.Status == "doing")
                {
                    await _createNotify.CreateNotifyAsync(task, "done", null);
                    task.Status = "done";
                    task.Percent = 100;
                }
                _context.Update(task);
                await _context.SaveChangesAsync();
                return _mapper.Map<TaskDto>(task);
            }
        }
    }
}
