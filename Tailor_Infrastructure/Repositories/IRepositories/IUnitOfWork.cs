using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IChatRepository ChatRepository { get; }
        IInventoryCategoryRepository InventoryCategoryRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        INotifyRepository NotifyRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        ISampleRepository SampleRepository { get; }
        ITaskRepository TaskRepository { get; }
        IUserSampleRepository UserSampleRepository { get; }
        IUserRepository UserRepository { get; }
        IImageProductRepository ImageProductRepository { get; }

        Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        void RollBack(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync();
    }
}
