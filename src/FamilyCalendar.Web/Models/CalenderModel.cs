using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using NodaTime;
using NodaTime.Extensions;

namespace FamilyCalendar.Web.Models
{
    public class CalenderModel
    {
        public CultureInfo CultureInfo { get; }

        public CalenderModel(CultureInfo cultureInfo)
        {
            CultureInfo = cultureInfo;
            var today = SystemClock.Instance.GetCurrentInstant().InUtc().Date;
            CurrentMonth = new MonthModel(CultureInfo, today);
            CurrentWeek = CurrentMonth.GetWeekModelOf(today);
        }

        public IEnumerable<DayModel> Days => GetWeekdays();
        public MonthModel CurrentMonth { get;}
        public WeekModel CurrentWeek { get;}
        private IEnumerable<DayModel> GetWeekdays()
        {
            var days = new DayModel[7];
            var dateTimeFormat = CultureInfo.DateTimeFormat;
            var firstDay = (int)dateTimeFormat.FirstDayOfWeek.ToIsoDayOfWeek();
            for (var i = 0; i < days.Length; i++)
            {
                var current = firstDay + i;
                if (current >= 8)
                {
                    current -= 7;
                }
                var currentDay = (IsoDayOfWeek)current;
                days[i] = new DayModel(dateTimeFormat.GetAbbreviatedDayName(currentDay.ToDayOfWeek()), currentDay);
            }
            return days;
        }
    }
}