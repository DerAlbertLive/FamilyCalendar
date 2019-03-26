namespace FamilyCalendar.Web.Configuration
{
    public class AccountOptions
    {
        private string _displayName;

        public string DisplayName
        {
            get => _displayName ?? Username;
            set => _displayName = value;
        }

        public string Username { get; set; }
        public string Password { get; set; }

        public string Tenant { get; set; } = "organizations";
    }
}