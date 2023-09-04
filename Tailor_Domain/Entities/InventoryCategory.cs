using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Domain.Entities
{
    public class InventoryCategory: BaseEnity<int>
    {
        public string Name { get; set; } = default!;
        public ICollection<Inventory> Inventories { get; set; }=new Collection<Inventory>();
    }
    public class InventoryCategoryConfiguration : IEntityTypeConfiguration<InventoryCategory>
    {
        public void Configure(EntityTypeBuilder<InventoryCategory> builder)
        {
            builder.HasMany<Inventory>(c => c.Inventories).WithOne(c => c.InventoryCategory).HasForeignKey(inventory=>inventory.InventoryCategoryId);
        }
    }
}
