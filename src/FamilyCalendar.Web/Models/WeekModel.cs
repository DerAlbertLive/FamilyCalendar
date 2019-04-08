using System;
using System.Collections.Generic;
using System.Globalization;

namespace FamilyCalendar.Web.Models
{
    public class WeekModel
    {
        private readonly CultureInfo _cultureInfo;
        private readonly DateTimeOffset _dateTime;

        public WeekModel(CultureInfo cultureInfo, DateTimeOffset dateTime)
        {
            _cultureInfo = cultureInfo;
            _dateTime = dateTime;
        }

        public IEnumerable<DayModel> Days => GetDays(_dateTime);

        private IEnumerable<DayModel> GetDays(DateTimeOffset dateTime)
        {
            var firstDayOfWeek = (int)_cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var currentDayOfWeek = (int)dateTime.DayOfWeek;
            if (currentDayOfWeek == 0)
            {
                currentDayOfWeek = 7;
            }
            var offsetDays = -(currentDayOfWeek - firstDayOfWeek);

            var startWeekDate = dateTime.AddDays(offsetDays);
            for (int i = 0; i < 7; i++)
            {
                var date = startWeekDate.AddDays(i);
                var dayModel = new DayModel(_cultureInfo, date);
                dayModel.IsInMonth = date.Month == dateTime.Month;
                yield return dayModel;
            }
        }
    }
}