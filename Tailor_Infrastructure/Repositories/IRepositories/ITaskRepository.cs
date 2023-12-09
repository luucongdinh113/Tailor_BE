using Tailor_Infrastructure.Dto.Task;
using Task = Tailor_Domain.Entities.Task;
namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface ITaskRepository : IGenericRepository<Task, int>
    {
        TaskDto CreateTask(CreateTask task);
        TaskDto UpdateTask(UpdateTask updateTask);
    }
}
