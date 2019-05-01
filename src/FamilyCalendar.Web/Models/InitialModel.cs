using NodaTime;

namespace FamilyCalendar.Web.Models
{
    public class InitialModel
    {
        readonly DateTimeZone _zone = DateTimeZoneProviders.Tzdb["Europe/Astrakhan"];
        public Person CreateDad()
        {
            var person = new Person()
            {
                Name = "Dad"
            };

            var today = SystemClock.Instance.GetCurrentInstant().InUtc();
            int year = today.Year;
            int month = today.Month;

            person.AddActivity(ActivityHelper.CreateForFullDate("Feiertag", year, month, 1, _zone));
            person.AddActivity(ActivityHelper.CreateForTime("LiveStream", year, month, 1,  11,00, 180, _zone));
            person.AddActivity(ActivityHelper.CreateForTime("LiveStream", year, month, 2,  12, 00, 60, _zone));
            person.AddActivity(ActivityHelper.CreateForTime("Was anders", year, month, 2,  14, 00, 60, _zone));

            return person;
        }
    }
}