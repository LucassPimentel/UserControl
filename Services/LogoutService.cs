using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserControl.Interfaces;
using UserControl.Models;

namespace UserControl.Services
{
    public class LogoutService : ILogoutService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogoutUser()
        {
            var identityResult = _signInManager.SignOutAsync();
            return identityResult.IsCompletedSuccessfully ? (Result.Ok()) : (Result.Fail("Logout falhou!"));
        }
    }
}
