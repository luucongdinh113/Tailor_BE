using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure
{
    public class TaiLorContext:DbContext
    {
        //private readonly ILoggedInUserService _loggedInUserService;
        private readonly IDateTimeProvider _dateTimeProvider;
        public TaiLorContext(DbContextOptions option, IDateTimeProvider dateTimeProvider, /*ILoggedInUserService loggedInUserService*/) : base(option) 
        {
            _dateTimeProvider= dateTimeProvider;
            //_loggedInUserService = loggedInUserService;
        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaiLorContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellation=default)
        {
            foreach (var entry in ChangeTracker.Entries<ISoftDelete>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt= DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<IUserInform>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = _dateTimeProvider.DatetTimeNowUtc;
                        entry.Entity.UpdatedBy = _loggedInUserService.UserId.ToString();
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTimeProvider.DateTimeOffsetUtc;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId.ToString();
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellation);
        }
    }
}