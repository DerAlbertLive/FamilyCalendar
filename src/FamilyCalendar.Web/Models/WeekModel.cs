using System;
using System.Collections.Generic;
using System.Globalization;
using NodaTime;

namespace FamilyCalendar.Web.Models
{
    public class WeekModel
    {
        private readonly CultureInfo _cultureInfo;
        private readonly LocalDate _date;

        public WeekModel(CultureInfo cultureInfo, LocalDate date)
        {
            _cultureInfo = cultureInfo;
            _date = date;
        }

        public IEnumerable<DayModel> Days => GetDays(_date);

        private IEnumerable<DayModel> GetDays(LocalDate localDate)
        {
            var firstDayOfWeek = (int)_cultureInfo.DateTimeFormat.FirstDayOfWeek;
            var currentDayOfWeek = (int)localDate.DayOfWeek;
            //if (currentDayOfWeek == 0)
            //{
            //    currentDayOfWeek = 7;
            //}
            var offsetDays = -(currentDayOfWeek - firstDayOfWeek);

            var startWeekDate = localDate.PlusDays(offsetDays);
            for (int i = 0; i < 7; i++)
            {
                var date = startWeekDate.PlusDays(i);
                var dayModel = new DayModel(_cultureInfo, date);
                dayModel.IsInMonth = date.Month == _date.Month;
                yield return dayModel;
            }
        }
    }
}