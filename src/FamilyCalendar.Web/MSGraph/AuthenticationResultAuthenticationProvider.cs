using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace FamilyCalendar.Web.MSGraph
{
    public class AuthenticationResultAuthenticationProvider : IAuthenticationProvider
    {
        private readonly AuthenticationResult _authResult;

        public AuthenticationResultAuthenticationProvider(AuthenticationResult authResult)
        {
            _authResult = authResult;
        }

        public Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _authResult.AccessToken);
            return Task.CompletedTask;
        }
    }
}