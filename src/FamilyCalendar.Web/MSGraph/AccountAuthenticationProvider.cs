using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Threading.Tasks;
using FamilyCalendar.Web.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace FamilyCalendar.Web.MSGraph
{
    public class AccountAuthenticationProvider : IAuthenticationProvider
    {
        private readonly AccountOptions _options;
        private readonly IOptions<Office365Options> _optionsAccessor;
        private AuthenticationResult _authResult;

        public AccountAuthenticationProvider(AccountOptions options, IOptions<Office365Options> optionsAccessor)
        {
            _options = options;
            _optionsAccessor = optionsAccessor;
        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            if (!AccessTokenValid())
            {
                _authResult = await AcquireAuthenticationAsync();
            }
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authResult.AccessToken);
        }

        private async Task<AuthenticationResult> AcquireAuthenticationAsync()
        {
            var authority = $"https://login.microsoftonline.com/{_options.Tenant}/";
            var app = new PublicClientApplication(_optionsAccessor.Value.ClientId, authority);
            string[] scopes = { "user.read", "calendars.read" };
            var password = GetSecureString(_options.Password);
            var authentication = await app.AcquireTokenByUsernamePasswordAsync(scopes, _options.Username, password);
            return authentication;
        }

        private SecureString GetSecureString(string password)
        {
            var sp = new SecureString();
            foreach (var c in password)
            {
                sp.AppendChar(c);
            }
            return sp;
        }

        private bool AccessTokenValid()
        {
            if (_authResult == null)
            {
                return false;
            }

            var currentTime = DateTimeOffset.UtcNow.AddMinutes(5);
            if (_authResult.ExpiresOn < currentTime)
            {
                return false;
            }
            return true;
        }
    }
}