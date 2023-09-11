using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Product
{
    public class ProductDto
    {
        public int Id { get;set; }
        public int ProductCategoryId { get; set; }
        public Tailor_Domain.Entities.ProductCategory ProductCategory { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public decimal Price { get; set; }
        public string Note { get; set; } = default!;
    }
}
