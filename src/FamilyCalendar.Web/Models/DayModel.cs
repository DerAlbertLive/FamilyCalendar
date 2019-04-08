using System;
using System.Globalization;

namespace FamilyCalendar.Web.Models
{
    public class DayModel
    {
        public DayModel(CultureInfo cultureInfo, DateTimeOffset date)
        {
            Day = date.Day;
            DayOfWeek = cultureInfo.Calendar.GetDayOfWeek(date.DateTime);
            DisplayName = cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek);
        }

        public DayModel(string dayName, DayOfWeek dayOfWeek)
        {
            DisplayName = dayName;
            DayOfWeek = dayOfWeek;
        }

        public string DisplayName { get; }

        public DayOfWeek DayOfWeek { get; }
        
        public int Day { get; }

        public bool IsInMonth { get; set; }
    }
}