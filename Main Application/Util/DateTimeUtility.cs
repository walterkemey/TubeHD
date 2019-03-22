using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTube.Util
{
    public class DateTimeUtility
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static long CurrentTimeMillis()
        {
            return (DateTime.UtcNow.Ticks - Epoch.Ticks) / TimeSpan.TicksPerMillisecond;
        }

        public static long ToUnixTime(DateTime date)
        {
            return Convert.ToInt64((date - Epoch).TotalSeconds);
        }

        public static DateTime GetNextSettlementDate_Weekly(int dayOfWeek, int hour)
        {
            DateTime dateNow = DateTime.Now.ToUniversalTime();
            DateTime dateSettlement = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, hour, 0, 0, DateTimeKind.Utc);

            // add more days while it is not a saturday
            while ((int)dateSettlement.DayOfWeek < dayOfWeek)
            {
                dateSettlement = dateSettlement.AddDays(1);
            }
            // if current settlement day is earlier than now
            while (dateSettlement.CompareTo(dateNow) <= 0)
            {
                dateSettlement = dateSettlement.AddDays(+7);
            }
            return dateSettlement;
        }
    }
}
