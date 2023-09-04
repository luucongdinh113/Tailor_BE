using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Domain.Entities
{
    public class Product: BaseEnity<int>
    {
        [ForeignKey(nameof(ProductCategoryId))]
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory{ get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public string Note { get; set; } = default!;

    }
}
