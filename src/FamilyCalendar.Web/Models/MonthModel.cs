using System;
using System.Collections.Generic;
using System.Globalization;

namespace FamilyCalendar.Web.Models
{
    public class MonthModel
    {
        private readonly CultureInfo _cultureInfo;
        private readonly DateTimeOffset _now;

        public MonthModel(CultureInfo cultureInfo, DateTimeOffset now)
        {
            _cultureInfo = cultureInfo;
            _now = now;
        }

        public IEnumerable<WeekModel> Weeks => GetWeeks(_now);

        private IEnumerable<WeekModel> GetWeeks(DateTimeOffset dateTime)
        {
            var firstDate = new DateTimeOffset(dateTime.Year, dateTime.Month, 1,0,0,0, dateTime.Offset);
            var lastDayOfMonth = _cultureInfo.Calendar.GetDaysInMonth(firstDate.Year, firstDate.Month);
            var lastDate = new DateTimeOffset(dateTime.Year, dateTime.Month, lastDayOfMonth,0,0,0, dateTime.Offset);

            var currentDate = firstDate;
            do
            {
                var week = new WeekModel(_cultureInfo, currentDate);
                yield return week;
                currentDate = currentDate.AddDays(7);
            } while (IsInWeek(currentDate, lastDate));
        }

        private  bool IsInWeek(DateTimeOffset currentDate, DateTimeOffset lastDate)
        {
            if (currentDate < lastDate)
            {
                return true;
            }

            var rule = _cultureInfo.DateTimeFormat.CalendarWeekRule;
            var firstDay = _cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var currentWeek = _cultureInfo.Calendar.GetWeekOfYear(currentDate.DateTime, rule, firstDay);
            var lastWeek = _cultureInfo.Calendar.GetWeekOfYear(lastDate.DateTime, rule, firstDay);
            return currentWeek == lastWeek;
        }
    }
}