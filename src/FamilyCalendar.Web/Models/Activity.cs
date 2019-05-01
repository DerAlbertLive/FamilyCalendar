using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace FamilyCalendar.Web.Models
{
    public class Activity
    {
        public Activity(ZonedDateTime begin)
        {
            Begin = begin;
            End = begin;
            FullDay = true;
        }

        public Activity()
        {
            
        }

        public ZonedDateTime Begin { get; set; }
        public ZonedDateTime End { get; set; }

        public bool FullDay { get; set; }

        [Required]
        [MaxLength(128)]
        public string Subject { get; set; }

        [MaxLength(256)]
        public string Location { get; set; }
    }
}