using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Business.Commons;
using Tailor_Infrastructure;
using Tailor_Infrastructure.Dto.Product;
using Tailor_Infrastructure.Dto.Task;
using Tailor_Infrastructure.Dto.User;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Business.Commands.User
{
    public class UpdateReadedNotifyCommand : ICommand<bool>
    {
        #region param
        public int Id { get; set; }

        #endregion
        public class UpdateReadedNotifyHandlerCommand : ICommandHandler<UpdateReadedNotifyCommand, bool>
        {
            private readonly TaiLorContext _context;
            public UpdateReadedNotifyHandlerCommand(TaiLorContext taiLorContext)
            {
                _context = taiLorContext;
            }

            public async Task<bool> Handle(UpdateReadedNotifyCommand request, CancellationToken cancellationToken)
            {
                var notify = await _context.Notifies.FirstOrDefaultAsync(c => c.Id.Equals(request.Id));
                if(notify == null)
                {
                    return false;
                }
                notify.IsRead = true;
                _context.Update(notify);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
