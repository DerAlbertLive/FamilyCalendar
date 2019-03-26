using FamilyCalendar.Web.Configuration;
using FamilyCalendar.Web.MSGraph;
using FluentAssertions;
using Microsoft.Extensions.Options;
using NSubstitute;
using Xunit;

namespace FamilyCalendar.Web.Tests.MSGraph
{
    public class AuthenticationProviderFactoryTests
    {
        private readonly AuthenticationProviderFactory _subject;

        public AuthenticationProviderFactoryTests()
        {
            _subject = new AuthenticationProviderFactory(CreateOptions());
        }

        private IOptions<Office365Options> CreateOptions()
        {
            var accessor = Substitute.For<IOptions<Office365Options>>();
            var options = new Office365Options();
            options.ClientId = "TheClient";
            options.Accounts = new[]
            {
                new AccountOptions() { Username = "foo@BAR" }, 
                new AccountOptions() { Username = "bar@foo" }, 
            };
            accessor.Value.Returns(options);
            return accessor;
        }

        [Fact]
        public void Should_get_an_provider_for_foo()
        {
            var provider = _subject.GetForUser("foo@BAR");
            provider.Should().NotBeNull();
        }

        [Fact]
        public void Should_get_an_provider_for_bar()
        {
            var provider = _subject.GetForUser("bar@FOO");
            provider.Should().NotBeNull();
        }     
        
        [Fact]
        public void Should_the_provider_for_bar_be_different_then_foo()
        {
            var providerBar = _subject.GetForUser("bar@FOO");
            var providerFoo = _subject.GetForUser("foo@BAR");

            providerBar.Should().NotBeSameAs(providerFoo);
        }

        [Fact]
        public void Should_return_no_provider_for_unknown_user()
        {
            var provider = _subject.GetForUser("unknown@FOO");
            provider.Should().BeNull();
        }

        [Fact]
        public void Should_return_the_same_instance_for_same_user()
        {
            var first = _subject.GetForUser("bar@FOO");
            var second = _subject.GetForUser("bar@FOO");

            first.Should().BeSameAs(second);
        }
    }
}