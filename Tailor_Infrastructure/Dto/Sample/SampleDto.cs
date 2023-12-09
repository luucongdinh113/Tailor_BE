using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Sample
{
    public class SampleDto
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public Tailor_Domain.Entities.ProductCategory ProductCategory { get; set; } = default!;

        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public string Note { get; set; } = default!;
        public double Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public bool IsMale { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool IsShow { get; set; }
    }
}
