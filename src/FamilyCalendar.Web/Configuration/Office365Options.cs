using System.Collections.Generic;
using System.Security;
using Microsoft.Identity.Client;

namespace FamilyCalendar.Web.Configuration
{
    public class Office365Options
    {
        public string ClientId { get; set; }
        public AccountOptions[] Accounts { get; set; }
    }
}