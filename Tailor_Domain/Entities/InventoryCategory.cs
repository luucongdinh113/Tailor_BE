using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tailor_Domain.Entities
{
    public class InventoryCategory: BaseEnity<int>
    {
        public string Name { get; set; } = default!;
        public List<Inventory> Inventories { get; set; }=new List<Inventory>();
    }
    public class InventoryCategoryConfiguration : IEntityTypeConfiguration<InventoryCategory>
    {
        public void Configure(EntityTypeBuilder<InventoryCategory> builder)
        {
            builder.HasMany<Inventory>(c => c.Inventories).WithOne(c => c.InventoryCategory).HasForeignKey(inventory=>inventory.InventoryCategoryId);
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
