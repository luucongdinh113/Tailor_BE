using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using System.Security.Principal;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Services;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure
{
    public class TaiLorContext:DbContext
    {
        private readonly ILoggedUserService _loggedInUserService;
        private readonly IDateTimeProvider _dateTimeProvider;
        public TaiLorContext(DbContextOptions option, IDateTimeProvider dateTimeProvider, ILoggedUserService loggedInUserService) : base(option)
        {
            _dateTimeProvider = dateTimeProvider;
            _loggedInUserService = loggedInUserService;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Inventory> Inventories{ get; set; }
        public DbSet<InventoryCategory> InventoryCategories  { get; set; }
        public DbSet<Notify> Notifies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories  { get; set; }
        public DbSet<Sample> Samples{ get; set; }
        public DbSet<Tailor_Domain.Entities.Task> Tasks  { get; set; }
        public DbSet<UserSample> User_Samples  { get; set; }
        public DbSet<ImagesProduct> ImagesProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new NotifyConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SampleConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserSampleConfiguration());
            modelBuilder.ApplyConfiguration(new ImagesProductConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries<ISoftDelete>())
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
            foreach (var entry in this.ChangeTracker.Entries<IUserInform>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = _dateTimeProvider.DatetTimeNowUtc;
                        entry.Entity.UpdatedBy = _loggedInUserService.UserName;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeProvider.DateTimeOffsetUtc;
                        entry.Entity.CreatedBy = _loggedInUserService.UserName;
                        entry.Entity.UpdatedDate = _dateTimeProvider.DatetTimeNowUtc;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync();
        }
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries<ISoftDelete>())
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
            foreach (var entry in this.ChangeTracker.Entries<IUserInform>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = _dateTimeProvider.DatetTimeNowUtc;
                        entry.Entity.UpdatedBy = _loggedInUserService.UserName;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeProvider.DateTimeOffsetUtc;
                        entry.Entity.UpdatedDate = _dateTimeProvider.DatetTimeNowUtc;
                        entry.Entity.CreatedBy = _loggedInUserService.UserName;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}