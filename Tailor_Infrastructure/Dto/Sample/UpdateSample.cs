using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.Sample
{
    public class UpdateSample
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }

        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Images { get; set; } = default!;
        public string Note { get; set; } = default!;
    }
}
