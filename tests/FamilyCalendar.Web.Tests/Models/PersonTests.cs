using System.Linq;
using FamilyCalendar.Web.Models;
using FluentAssertions;
using Microsoft.Graph;
using NodaTime;
using Xunit;
using Person = FamilyCalendar.Web.Models.Person;

namespace FamilyCalendar.Web.Tests.Models
{
    public class PersonTests
    {
        [Fact]
        public void Should_an_an_activity()
        {
            var activity = new Activity();

            var subject = new Person();
            subject.AddActivity(activity);

            subject.Activities[0].Should().BeSameAs(activity);
        }

        [Fact]
        public void Should_an_two_activities()
        {
            var activity1 = new Activity();
            var activity2 = new Activity();

            var subject = new Person();
            subject.AddActivity(activity1);
            subject.AddActivity(activity2);

            subject.Activities[0].Should().BeSameAs(activity1);
            subject.Activities[1].Should().BeSameAs(activity2);
        }

        [Fact]
        public void Should_add_two_activities_and_remove_first()
        {
            var activity1 = new Activity();
            var activity2 = new Activity();

            var subject = new Person();
            subject.AddActivity(activity1);
            subject.AddActivity(activity2);
            subject.RemoveActivity(activity1);

            subject.Activities[0].Should().BeSameAs(activity2);
        }

        [Fact]
        public void Should_get_activity_for_a_specific_date()
        {
            DateTimeZone zone = DateTimeZoneProviders.Tzdb["Europe/Berlin"];
            var begin = new ZonedDateTime(Instant.FromUtc(2019,5,1,14,00), zone);
            var activity1 = new Activity(begin);
            begin = new ZonedDateTime(Instant.FromUtc(2019,5,2,15,00), zone);
            var activity2 = new Activity(begin);
            begin = new ZonedDateTime(Instant.FromUtc(2019,5,1,15,00), zone);
            var activity3 = new Activity(begin);

            var subject = new Person(); 
            subject.AddActivity(activity1);
            subject.AddActivity(activity2);
            subject.AddActivity(activity3);

            var result = subject.GetActivitiesForDate(new LocalDate(2019, 5, 1), zone);
            result.Count.Should().Be(2);

            result.Should().Contain(new[] {activity1, activity3});
        }
    }
}