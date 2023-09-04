using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;
using System.Security.Principal;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure
{
    public class TaiLorContext:DbContext
    {
        
        public TaiLorContext(DbContextOptions option) : base(option)
        {  }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new SampleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryCategoryConfiguration());
        }
    }
}