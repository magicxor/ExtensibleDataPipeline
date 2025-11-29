using System;

namespace Edp.Common.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime TimestampToUtcDateTime(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
        }
    }
}
