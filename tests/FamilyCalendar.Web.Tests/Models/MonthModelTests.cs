using System;
using System.Globalization;
using System.Linq;
using FamilyCalendar.Web.Models;
using FluentAssertions;
using Xunit;

namespace FamilyCalendar.Web.Tests.Models
{
    public class MonthModelTests
    {
        [Fact]
        public void Five_Weeks_of_month_of_2019_04_08()
        {
            var calendar = new MonthModel(new CultureInfo("de-DE"),
                new DateTimeOffset(2019, 4, 8, 12, 0, 0, TimeSpan.FromHours(0)));

            var weeks = calendar.Weeks.ToArray();

            weeks.Length.Should().Be(5);
        }

        [Fact]
        public void Correct_Weeks_of_month_of_2019_04_08()
        {
            var calendar = new MonthModel(new CultureInfo("de-DE"),
                new DateTimeOffset(2019, 4, 8, 12, 0, 0, TimeSpan.FromHours(0)));

            var weeks = calendar.Weeks.ToArray();
            weeks[0].Days.First().Day.Should().Be(1);
            weeks[1].Days.First().Day.Should().Be(8);
            weeks[2].Days.First().Day.Should().Be(15);
            weeks[3].Days.First().Day.Should().Be(22);
            weeks[4].Days.First().Day.Should().Be(29);
        }
        [Fact]
        public void Five_Weeks_of_month_of_2019_03_08()
        {
            var calendar = new MonthModel(new CultureInfo("de-DE"),
                new DateTimeOffset(2019, 3, 8, 12, 0, 0, TimeSpan.FromHours(0)));

            var weeks = calendar.Weeks.ToArray();

            weeks.Length.Should().Be(5);
        }
        [Fact]
        public void Five_Weeks_of_month_of_2019_02_08()
        {
            var calendar = new MonthModel(new CultureInfo("de-DE"),
                new DateTimeOffset(2019, 2, 8, 12, 0, 0, TimeSpan.FromHours(0)));

            var weeks = calendar.Weeks.ToArray();

            weeks.Length.Should().Be(5);
        }

        [Fact]
        public void Four_Weeks_of_month_of_2010_02_08()
        {
            var calendar = new MonthModel(new CultureInfo("de-DE"),
                new DateTimeOffset(2010, 2, 8, 12, 0, 0, TimeSpan.FromHours(0)));

            var weeks = calendar.Weeks.ToArray();

            weeks.Length.Should().Be(4);
        }

        [Fact]
        public void Six_Weeks_of_month_of_2019_09_08()
        {
            var calendar = new MonthModel(new CultureInfo("de-DE"),
                new DateTimeOffset(2019, 9, 8, 12, 0, 0, TimeSpan.FromHours(0)));

            var weeks = calendar.Weeks.ToArray();

            weeks.Length.Should().Be(6);
        }
    }
}