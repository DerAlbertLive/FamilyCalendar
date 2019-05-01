using System;
using System.Collections.Generic;
using NodaTime;

namespace FamilyCalendar.Web.Models
{
    public class Person
    {
        private readonly List<Activity> _activities;
        
        public Person()
        {
            _activities = new List<Activity>();
        }

        public IReadOnlyList<Activity> Activities => _activities;
        public string Name { get; set; }

        public void AddActivity(Activity activity)
        {
            _activities.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            _activities.Remove(activity);   
        }

        public IReadOnlyCollection<Activity> GetActivitiesForDate(LocalDate date, DateTimeZone localZone)
        {
            var resultActivities =  new List<Activity>();
            foreach (var activity in _activities)
            {
                var localBegin = activity.Begin.WithZone(localZone).Date;
                var localEnd = activity.End.WithZone(localZone).Date;
                if (localBegin >= date && localEnd <= date)
                {
                    resultActivities.Add(activity);
                }
            }

            return resultActivities;
        }
    }
}