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
            public UpdateInfoTaskHandlerCommand(TaiLorContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<TaskDto> Handle(UpdateInfoTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.Tasks.Where(c => c.Id == request.Id).FirstOrDefaultAsync() ??
                    throw new Exception($"Not found object Task has Id = {request.Id}");
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
                if (request.Percent == 100 && request.Status == "doing") task.Status= "done";
                _context.Update(task);
                await _context.SaveChangesAsync();
                return _mapper.Map<TaskDto>(task);
            }
        }
    }
}
