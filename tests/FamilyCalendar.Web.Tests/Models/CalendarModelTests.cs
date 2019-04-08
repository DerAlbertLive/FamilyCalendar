using System;
using System.Globalization;
using System.Linq;
using FamilyCalendar.Web.Models;
using FluentAssertions;
using Xunit;

namespace FamilyCalendar.Web.Tests.Models
{
    public class CalendarModelTests
    {

        public CalendarModelTests()
        {
        }

        [Fact]
        public void With_Culture_de_de_Days_should_be_in_order_Mo_Di_Mi_Do_Fr_Sa_So()
        {
            var calendar = new CalenderModel(new CultureInfo("de-DE"));
            var days = calendar.Days.ToArray();
            days[0].DisplayName.Should().Be("Mo");
            days[1].DisplayName.Should().Be("Di");
            days[2].DisplayName.Should().Be("Mi");
            days[3].DisplayName.Should().Be("Do");
            days[4].DisplayName.Should().Be("Fr");
            days[5].DisplayName.Should().Be("Sa");
            days[6].DisplayName.Should().Be("So");
        }

        [Fact]
        public void With_culture_en_us_Days_should_be_in_order_So_Mi_Di_Mi_Do_Fr_Sa()
        {
            var cultureInfo = new CultureInfo("en-US");
            var calendar = new CalenderModel(cultureInfo);
            var days = calendar.Days.ToArray();
            days[0].DisplayName.Should().Be("Sun");
            days[1].DisplayName.Should().Be("Mon");
            days[2].DisplayName.Should().Be("Tue");
            days[3].DisplayName.Should().Be("Wed");
            days[4].DisplayName.Should().Be("Thu");
            days[5].DisplayName.Should().Be("Fri");
            days[6].DisplayName.Should().Be("Sat");
        }

        [Fact]
        public void With_culture_en_us_and_first_day_is_Wednesday_Days_should_be_in_order_Wed_Thu_Fri_Sat_Sun_Mon_Tue()
        {
            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Wednesday;
            var calendar = new CalenderModel(cultureInfo);
            var days = calendar.Days.ToArray();
            days[0].DisplayName.Should().Be("Wed");
            days[1].DisplayName.Should().Be("Thu");
            days[2].DisplayName.Should().Be("Fri");
            days[3].DisplayName.Should().Be("Sat");
            days[4].DisplayName.Should().Be("Sun");
            days[5].DisplayName.Should().Be("Mon");
            days[6].DisplayName.Should().Be("Tue");
        }
    }
}