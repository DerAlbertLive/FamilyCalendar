using System;
using NodaTime;
using NodaTime.Extensions;

namespace FamilyCalendar.Web.Models
{
    // based on https://cmikavac.net/2018/04/05/converting-to-and-from-local-time-in-c-net-with-noda-time/
    public static class DateTimeExtensions
    {
       
        
        /// <summary>
        /// Converts a local-time DateTime to UTC DateTime based on the specified
        /// timezone. The returned object will be of UTC DateTimeKind. To be used
        /// when we want to know what's the UTC representation of the time somewhere
        /// in the world.
        /// </summary>
        /// <param name="dateTime">Local DateTime as UTC or Unspecified DateTimeKind.</param>
        /// <param name="timezone">Timezone name (in TZDB format).</param>
        /// <returns>UTC DateTime as UTC DateTimeKind.</returns>
        public static ZonedDateTime InZone(this DateTime dateTime, DateTimeZone zone)
        {
            if (dateTime.Kind == DateTimeKind.Local)
                throw new ArgumentException("Expected non-local kind of DateTime");

            LocalDateTime asLocal = dateTime.ToLocalDateTime();
            ZonedDateTime asZoned = asLocal.InZoneLeniently(zone);
            return asZoned;
        }
    }
}