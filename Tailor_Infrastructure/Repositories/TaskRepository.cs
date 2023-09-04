using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;
using Task = Tailor_Domain.Entities.Task;

namespace Tailor_Infrastructure.Repositories
{
    public class TaskRepository : GenericRepository<Task, int>, ITaskRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        public TaskRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
    }
}
