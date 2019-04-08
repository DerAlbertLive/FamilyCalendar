using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace FamilyCalendar.Web.Models
{
    public class CalenderModel
    {
        private readonly CultureInfo _cultureInfo;

        public CalenderModel(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
            CurrentMonth = new MonthModel(_cultureInfo, DateTimeOffset.Now);
        }

        public IEnumerable<DayModel> Days => GetWeekdays();
        public MonthModel CurrentMonth { get; private set; }

        private IEnumerable<DayModel> GetWeekdays()
        {
            var days = new DayModel[7];
            var dateTimeFormat = _cultureInfo.DateTimeFormat;
            var firstDay = (int)dateTimeFormat.FirstDayOfWeek;
            for (var i = 0; i < days.Length; i++)
            {
                var current = firstDay + i;
                if (current >= 7)
                {
                    current -= 7;
                }
                var currentDay = (DayOfWeek)current;
                days[i] = new DayModel(dateTimeFormat.GetAbbreviatedDayName(currentDay), currentDay);
            }
            return days;
        }
    }
}