using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.Sample;
using Task = System.Threading.Tasks.Task;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface INotifyRepository: IGenericRepository<Notify, int>
    {
        
    }
}
