using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using UserControl.Models;
using UserControl.Services;
using Xunit;

namespace UserControl.Unit_Tests.Services
{
    public class TokenServiceTests
    {
        [Fact]
        public void CreateToken_WhenCreateToken_ShouldReturnToken()
        {
            var identityUser = new CustomIdentityUser() { Id = 1, UserName = "Teste", BirthDate = DateTime.Parse("2000-01-20")};

            var tokenService = new TokenService();

            var token = tokenService.CreateToken(identityUser, "admin");

            token.Should().NotBeNull();
        }
    }
}
