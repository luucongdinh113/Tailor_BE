using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.ProductCategory
{
    public class UpdateProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
