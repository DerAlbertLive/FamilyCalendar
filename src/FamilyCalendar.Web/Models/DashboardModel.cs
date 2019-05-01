using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace FamilyCalendar.Web.Models
{
    public class DashboardModel
    {
        public DashboardModel()
        {
            var data = new InitialModel();
            Calender = new CalenderModel(CultureInfo.CurrentCulture);
            People = new[]
            {
                data.CreateDad(),
            };
        }
        public CalenderModel Calender { get; }

        public IReadOnlyCollection<Person> People { get; }
    }
}