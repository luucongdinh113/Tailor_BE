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
            public UpdateStatusTaskHandlerCommand(TaiLorContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<TaskDto> Handle(UpdateStatusTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _context.Tasks.Where(c => c.Id == request.Id).FirstOrDefaultAsync() ??
                    throw new Exception($"Not found object Task has Id = {request.Id}");
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
