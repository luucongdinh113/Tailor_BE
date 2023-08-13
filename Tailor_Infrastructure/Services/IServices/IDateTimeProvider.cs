using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Services.IServices
{
    public interface IDateTimeProvider
    {
        public DateTime DateTimeNow { get; }
        public DateTime DatetTimeNowUtc { get; }
        public DateTimeOffset DateTimeOffsetNow { get; }
        public DateTimeOffset DateTimeOffsetUtc { get; }
    }
}
