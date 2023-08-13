using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow => DateTime.Now;

        public DateTimeOffset DateTimeOffsetNow => DateTimeOffset.Now;

        public DateTimeOffset DateTimeOffsetUtc => DateTimeOffset.UtcNow;

        public DateTime DatetTimeNowUtc => DateTime.UtcNow;
    }
}
