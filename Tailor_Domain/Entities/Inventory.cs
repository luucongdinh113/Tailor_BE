using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tailor_Domain.Entities
{
    public class Inventory: BaseEnity<int>
    {
        [ForeignKey(nameof(InventoryCategoryId))]
        public int InventoryCategoryId { get; set; }
        public InventoryCategory InventoryCategory { get; set; } = default!;

        public string Name { get; set; } = default!;
        public string Describe { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Used { get; set; }
    }
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasQueryFilter(c => c.IsDeleted == false || c.IsDeleted == null);
        }
    }
}
