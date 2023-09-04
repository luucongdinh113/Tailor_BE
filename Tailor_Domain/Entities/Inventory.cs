using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
