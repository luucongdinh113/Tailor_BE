using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Inventory
{
    public class UpdateInventory
    {
        public int Id { get; set; }
        public int InventoryCategoryId { get; set; }
        public string Name { get; set; } = default!;
        public string Describe { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Used { get; set; }
    }
}
