using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailor_Infrastructure.Services.IServices
{
    public interface ICreateNotify
    {
        System.Threading.Tasks.Task CreateNotifyAsync(Tailor_Domain.Entities.Task task, string status, int? percent);
        Task CheckAdmin();
    }
}
