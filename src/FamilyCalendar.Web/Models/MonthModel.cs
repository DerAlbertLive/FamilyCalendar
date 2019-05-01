using System;
using System.Collections.Generic;
using System.Globalization;
using NodaTime;

namespace FamilyCalendar.Web.Models
{
    public class MonthModel
    {
        private readonly CultureInfo _cultureInfo;
        private readonly LocalDate _today;

        public MonthModel(CultureInfo cultureInfo, LocalDate today)
        {
            _cultureInfo = cultureInfo;
            _today = today;
        }

        public IEnumerable<WeekModel> Weeks => GetWeeks(_today);

        private IEnumerable<WeekModel> GetWeeks(LocalDate dateTime)
        {
            var firstDate = new LocalDate(dateTime.Year, dateTime.Month, 1);
            var lastDayOfMonth = _cultureInfo.Calendar.GetDaysInMonth(firstDate.Year, firstDate.Month);
            var lastDate = new LocalDate(dateTime.Year, dateTime.Month, lastDayOfMonth);

            var currentDate = firstDate;
            do
            {
                var week = new WeekModel(_cultureInfo, currentDate);
                yield return week;
                currentDate = currentDate.PlusDays(7);
            } while (IsInWeek(currentDate, lastDate));
        }

        private  bool IsInWeek(LocalDate currentDate, LocalDate lastDate)
        {
            if (currentDate < lastDate)
            {
                return true;
            }
            var rule = _cultureInfo.DateTimeFormat.CalendarWeekRule;
            var firstDay = _cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var currentWeek = _cultureInfo.Calendar.GetWeekOfYear(currentDate.ToDateTimeUnspecified(), rule, firstDay);
            var lastWeek = _cultureInfo.Calendar.GetWeekOfYear(lastDate.ToDateTimeUnspecified(), rule, firstDay);
            return currentWeek == lastWeek;
        }
    }
}