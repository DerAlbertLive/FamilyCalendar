using System;
using System.Globalization;
using System.Linq;
using FamilyCalendar.Web.Models;
using FluentAssertions;
using NodaTime;
using Xunit;

namespace FamilyCalendar.Web.Tests.Models
{
    public class WeekModelTests
    {
        [Fact]
        public void Days_of_week_2019_04_08()
        {
            var week = new WeekModel(new CultureInfo("de-DE"), new LocalDate(2019, 4, 8));
            var days = week.Days.ToArray();
            days.Length.Should().Be(7);

            days[0].Day.Should().Be(8);
            days[0].DayOfWeek.Should().Be(IsoDayOfWeek.Monday);
            days[0].DisplayName.Should().Be("Mo");
            days[1].Day.Should().Be(9);
            days[1].DayOfWeek.Should().Be(IsoDayOfWeek.Tuesday);
            days[1].DisplayName.Should().Be("Di");
            days[2].Day.Should().Be(10);
            days[3].Day.Should().Be(11);
            days[4].Day.Should().Be(12);
            days[5].Day.Should().Be(13);
            days[6].Day.Should().Be(14);
        }

        [Fact]
        public void Days_of_week_2019_04_14()
        {
            var week = new WeekModel(new CultureInfo("de-DE"), new LocalDate(2019, 4, 14));
            var days = week.Days.ToArray();

            days.Length.Should().Be(7);

            days[0].Day.Should().Be(8);
            days[0].DayOfWeek.Should().Be(IsoDayOfWeek.Monday);
            days[0].DisplayName.Should().Be("Mo");
            days[1].Day.Should().Be(9);
            days[1].DayOfWeek.Should().Be(IsoDayOfWeek.Tuesday);
            days[1].DisplayName.Should().Be("Di");
            days[2].Day.Should().Be(10);
            days[3].Day.Should().Be(11);
            days[4].Day.Should().Be(12);
            days[5].Day.Should().Be(13);
            days[6].Day.Should().Be(14);
        }

        [Fact]
        public void Days_of_week_2019_04_11()
        {
            var week = new WeekModel(new CultureInfo("de-DE"), new LocalDate(2019, 4, 11));
            var days = week.Days.ToArray();

            days.Length.Should().Be(7);

            days[0].Day.Should().Be(8);
            days[0].DayOfWeek.Should().Be(IsoDayOfWeek.Monday);
            days[0].DisplayName.Should().Be("Mo");
            days[1].Day.Should().Be(9);
            days[1].DayOfWeek.Should().Be(IsoDayOfWeek.Tuesday);
            days[1].DisplayName.Should().Be("Di");
            days[2].Day.Should().Be(10);
            days[3].Day.Should().Be(11);
            days[4].Day.Should().Be(12);
            days[5].Day.Should().Be(13);
            days[6].Day.Should().Be(14);
        }

        [Fact]
        public void Days_of_week_2019_03_01()
        {
            var week = new WeekModel(new CultureInfo("de-DE"), new LocalDate(2019, 3, 1));
            var days = week.Days.ToArray();

            days.Length.Should().Be(7);
            days[0].Day.Should().Be(25);
            days[1].Day.Should().Be(26);
            days[2].Day.Should().Be(27);
            days[3].Day.Should().Be(28);
            days[4].Day.Should().Be(1);
            days[5].Day.Should().Be(2);
            days[6].Day.Should().Be(3);
        }

        [Fact]
        public void Days_of_week_2019_03_01_and_en_us()
        {
            var week = new WeekModel(new CultureInfo("en-US"), new LocalDate(2019, 3, 1));
            var days = week.Days.ToArray();

            days.Length.Should().Be(7);
            days[0].Day.Should().Be(24);
            days[1].Day.Should().Be(25);
            days[2].Day.Should().Be(26);
            days[3].Day.Should().Be(27);
            days[4].Day.Should().Be(28);
            days[5].Day.Should().Be(1);
            days[6].Day.Should().Be(2);
        }
    }
}