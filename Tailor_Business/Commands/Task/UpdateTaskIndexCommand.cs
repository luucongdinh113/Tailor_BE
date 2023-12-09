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
    public class UpdateTaskIndexCommand: ICommand<Unit>
    {
        #region param
        public List<InuputUpdateIndex> listInputs { get; set; } = new List<InuputUpdateIndex>();
        #endregion
        public class UpdateTaskIndexHandleCommand : ICommandHandler<UpdateTaskIndexCommand, Unit>
        {
            private readonly TaiLorContext _context;
            public UpdateTaskIndexHandleCommand(TaiLorContext context)
            {
                _context= context;
            }

            public async Task<Unit> Handle(UpdateTaskIndexCommand request, CancellationToken cancellationToken)
            {
                var listIds = request.listInputs.Select(c => c.Id);
                var listTasksDb = await _context.Tasks.Where(c => listIds.Contains(c.Id)).ToListAsync();
                foreach (var item in listTasksDb)
                {
                    item.Index = request.listInputs.Where(c => c.Id == item.Id).Select(c => c.Index).FirstOrDefault();
                }
                _context.UpdateRange(listTasksDb);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
    public class InuputUpdateIndex
    {
        public int Id { get; set; }
        public int Index { get; set; }
    }
}
