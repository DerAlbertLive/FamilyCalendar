using System;
using System.Globalization;
using NodaTime;
using NodaTime.Extensions;

namespace FamilyCalendar.Web.Models
{
    public class DayModel
    {

        public DayModel(CultureInfo cultureInfo, LocalDate date)
        {
            Date = date;
            Day = date.Day;
            DayOfWeek = date.DayOfWeek;
            DisplayName = cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DayOfWeek.ToDayOfWeek());
        }

        public DayModel(string dayName, IsoDayOfWeek dayOfWeek)
        {
            DisplayName = dayName;
            DayOfWeek = dayOfWeek;
        }

        public LocalDate Date { get; }

        public string DisplayName { get; }

        public IsoDayOfWeek DayOfWeek { get; }
        
        public int Day { get; }

        public bool IsInMonth { get; set; }
    }
}