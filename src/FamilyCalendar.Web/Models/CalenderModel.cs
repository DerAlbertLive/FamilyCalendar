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
        private readonly CultureInfo _cultureInfo;

        public CalenderModel(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
            CurrentMonth = new MonthModel(_cultureInfo, SystemClock.Instance.GetCurrentInstant().InUtc().Date);
        }

        public IEnumerable<DayModel> Days => GetWeekdays();
        public MonthModel CurrentMonth { get; private set; }

        private IEnumerable<DayModel> GetWeekdays()
        {
            var days = new DayModel[7];
            var dateTimeFormat = _cultureInfo.DateTimeFormat;
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