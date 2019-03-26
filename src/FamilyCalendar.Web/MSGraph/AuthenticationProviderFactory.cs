using System;
using System.Collections.Concurrent;
using System.Linq;
using FamilyCalendar.Web.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Graph;

namespace FamilyCalendar.Web.MSGraph
{
    public class AuthenticationProviderFactory
    {
        private readonly IOptions<Office365Options> _optionsAccessor;
        private readonly ConcurrentDictionary<string, IAuthenticationProvider> _providers = 
            new ConcurrentDictionary<string, IAuthenticationProvider>(StringComparer.OrdinalIgnoreCase);
        public AuthenticationProviderFactory(IOptions<Office365Options> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        public IAuthenticationProvider GetForUser(string username)
        {
            if (_providers.TryGetValue(username, out var provider))
            {
                return provider;
            }

            var account = _optionsAccessor.Value.Accounts.FirstOrDefault(a =>
                string.Equals(username, a.Username, StringComparison.OrdinalIgnoreCase));

            if (account == null)
            {
                return null;
            }
            var authenticationProvider = new AccountAuthenticationProvider(account, _optionsAccessor);
            _providers.TryAdd(username, authenticationProvider);
            return authenticationProvider;
        }
    }
}