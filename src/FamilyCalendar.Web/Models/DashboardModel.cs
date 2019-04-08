using System.Collections;
using System.Globalization;
using System.Threading;

namespace FamilyCalendar.Web.Models
{
    public class DashboardModel
    {
        public DashboardModel()
        {
            Calender = new CalenderModel(CultureInfo.CurrentCulture);
        }
        public CalenderModel Calender { get; set; }
    }
}