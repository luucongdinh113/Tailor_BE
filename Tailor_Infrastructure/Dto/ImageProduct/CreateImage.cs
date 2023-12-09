using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.ImageProduct
{
    public class CreateImage
    {
        public int ProductId { get; set; }
        public string LinkImage { get; set; } = default!;
    }
}
