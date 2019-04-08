using System;
using System.Globalization;
using FamilyCalendar.Web.Models;
using FluentAssertions;
using Xunit;

namespace FamilyCalendar.Web.Tests.Models
{
    public class DayModelTests
    {
        private CultureInfo _cultureInfo;

        public DayModelTests()
        {
            _cultureInfo = new CultureInfo("de-DE");
        }

        [Fact]
        public void Day_for_2019_04_08()
        {
            var day = new DayModel(_cultureInfo, new DateTimeOffset(2019, 4, 8, 18, 0, 0, TimeSpan.FromHours(0)));
            day.DayOfWeek.Should().Be(DayOfWeek.Monday);
            day.DisplayName.Should().Be("Mo");
            day.Day.Should().Be(8);
        }
    }
}