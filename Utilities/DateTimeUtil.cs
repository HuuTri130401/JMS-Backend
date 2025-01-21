using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class DateTimeUtil
    {
        public static DateTimeOffset GetCurrentTime()
        {
            return DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
        }
    }
}
