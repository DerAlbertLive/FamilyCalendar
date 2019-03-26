using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using FamilyCalendar.Web.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace FamilyCalendar.Web.MSGraph
{
    public class TestAccessService
    {
        private readonly IOptions<Office365Options> _optionsAccessor;

        public TestAccessService(IOptions<Office365Options> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public async Task CheckAsync()
        {
            try
            {
                var account = _optionsAccessor.Value.Accounts.First();
                var serviceClient = new GraphServiceClient(new AccountAuthenticationProvider(account, _optionsAccessor));

                var events = await serviceClient.Me.Events.Request()
                    .Select("subject,organizer,start,end")
                    .OrderBy("createdDateTime DESC")
                    .GetAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }


}