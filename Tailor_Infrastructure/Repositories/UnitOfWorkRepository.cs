using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tailor_Infrastructure.Services.IServices;
using System.Drawing.Printing;
using AutoMapper;

namespace Tailor_Infrastructure.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly TaiLorContext _dbContext;
        private readonly ILoggedUserService _loggedInUserService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IMapper _mapper;

        private IDbContextTransaction? _dbContextTransaction;
        private IChatRepository? _chatRepository;
        private IInventoryCategoryRepository? _inventoryCategoryRepository;
        private IInventoryRepository? _inventoryRepository;
        private IMeasurement_InformationRepository? _measurementInformationRepository;
        private INotifyRepository? _notifyRepository;
        private IProductCategoryRepository? _productCategoryRepository;
        private IProductRepository? _productRepository;
        private ISampleRepository? _sampleRepository;
        private ITaskRepository? _taskRepository;
        private IUserSampleRepository? _userSampleRepository;
        private IUserRepository? _userRepository;

        public UnitOfWorkRepository(TaiLorContext context, IDateTimeProvider dateTimeProvider, ILoggedUserService loggedInUserService, IMapper mapper)
        {
            _dbContext = context;
            _dateTimeProvider = dateTimeProvider;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public IChatRepository ChatRepository=>_chatRepository??new ChatRepository(_dbContext,this,_mapper);
        public IInventoryCategoryRepository InventoryCategoryRepository => _inventoryCategoryRepository?? new InventoryCategoryRepository(_dbContext,this, _mapper);
        public IInventoryRepository InventoryRepository => _inventoryRepository ?? new InventoryRepository(_dbContext, this, _mapper);
        public IMeasurement_InformationRepository MeasurementInformationRepository => _measurementInformationRepository ?? new MeasurementInformationRepository(_dbContext, this, _mapper);
        public INotifyRepository NotifyRepository => _notifyRepository ?? new NotifyRepository(_dbContext, this, _mapper);
        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository ?? new ProductCategoryRepository(_dbContext, this, _mapper);
        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_dbContext, this, _mapper);
        public ISampleRepository SampleRepository => _sampleRepository ?? new SampleRepository(_dbContext, this, _mapper);
        public ITaskRepository TaskRepository => _taskRepository ?? new TaskRepository(_dbContext, this, _mapper);
        public IUserSampleRepository UserSampleRepository => _userSampleRepository ?? new UserSampleRepository(_dbContext, this, _mapper );
        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_dbContext, this, _mapper);

        public async Task<IDisposable> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _dbContextTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            return _dbContextTransaction;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContextTransaction != null)
            {
                await _dbContextTransaction.CommitAsync(cancellationToken);
            }
        }

        public void RollBack(CancellationToken cancellationToken = default)
        {
            if (_dbContextTransaction != null)
                _dbContextTransaction.Rollback();
        }

        public async Task<int> SaveChangesAsync()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries<ISoftDelete>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            foreach (var entry in _dbContext.ChangeTracker.Entries<IUserInform>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = _dateTimeProvider.DatetTimeNowUtc;
                        entry.Entity.UpdatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeProvider.DateTimeOffsetUtc;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    default:
                        break;
                }
            }
            return await _dbContext.SaveChangesAsync();
        }
    }
}
