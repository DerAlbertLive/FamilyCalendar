using System;
using NodaTime;
using NodaTime.Extensions;

namespace FamilyCalendar.Web.Models
{
    public static class ActivityHelper
    {
        public static Activity CreateForFullDate(string subject, int year, int month, int day, DateTimeZone zone)
        {
            var instant = Instant.FromUtc(year, month, day, 0, 0);
            var unspecified = new DateTime(year, month,day, 0,0,0, DateTimeKind.Unspecified);
            var begin = unspecified.InZone(zone);
            return new Activity
            {
                Begin = begin,
                End = begin,
                FullDay = true,
                Subject = subject
            };
        }

        public static Activity CreateForTime(string subject, int year, int month, int day, int hour, int minute, int duration, DateTimeZone zone)
        {
            var clock = SystemClock.Instance.InZone(zone);
            var unspecified = new DateTime(year, month,day,hour,minute,0, DateTimeKind.Unspecified);
            var begin = unspecified.InZone(zone);

            return new Activity
            {
                Begin = begin,
                End = begin.PlusMinutes(duration),
                FullDay = false,
                Subject = subject
            };
        }
    }
}