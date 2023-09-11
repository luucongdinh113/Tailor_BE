using Tailor_Domain.Entities;
namespace Tailor_Infrastructure.Dto.Inventory
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int InventoryCategoryId { get; set; }
        public Tailor_Domain.Entities.InventoryCategory InventoryCategory { get; set; } = default!;

        public string Name { get; set; } = default!;
        public string Describe { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
