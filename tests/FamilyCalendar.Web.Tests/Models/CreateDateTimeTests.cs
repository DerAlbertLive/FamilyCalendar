using FamilyCalendar.Web.Models;
using FluentAssertions;
using NodaTime;
using Xunit;

namespace FamilyCalendar.Web.Tests.Models
{
    public class CreateDateTimeTests
    {
        [Fact]
        public void Foo()
        {
             DateTimeZone zone = DateTimeZoneProviders.Tzdb["Europe/Astrakhan"];
             DateTimeZone localZone = DateTimeZoneProviders.Tzdb["Europe/Berlin"];

             var activity = ActivityHelper.CreateForTime("Foo", 2019, 5, 1, 10, 0, 60, zone);

             activity.Begin.Hour.Should().Be(10);
             activity.Begin.Day.Should().Be(1);

             var localBegin = activity.Begin.WithZone(localZone);
             localBegin.Hour.Should().Be(8);
        }
    }
}