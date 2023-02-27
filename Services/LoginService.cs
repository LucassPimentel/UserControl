using FluentResults;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Identity;
using UserControl.Dtos.Requests;
using UserControl.Interfaces;
using UserControl.Models;

namespace UserControl.Services
{
    public class LoginService : ILoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private ITokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LoginUser(LoginRequest loginRequest)
        {
            var requestResult = _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);

            if (requestResult.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(user => user.NormalizedUserName == loginRequest.Username.ToUpper());

                var token = _tokenService
                    .CreateToken(identityUser, _signInManager
                    .UserManager
                    .GetRolesAsync(identityUser)
                    .Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("login falhou");
        }

        public Result RequireResetPassword(RequireResetPasswordRequest requireResetRequest)
        {
            CustomIdentityUser? user = GetUserByEmail(requireResetRequest.Email);

            if (user != null)
            {
                var recoveryCode = _signInManager
                    .UserManager.GeneratePasswordResetTokenAsync(user).Result;
                return Result.Ok().WithSuccess(recoveryCode);
            }
            return Result.Fail("Erro ao solicitar redefinição de senha.");
        }

        public Result ResetPassword(ResetPassowordRequest resetRequest)
        {
            var user = GetUserByEmail(resetRequest.Email);

            var result = _signInManager
                .UserManager.ResetPasswordAsync(user, resetRequest.Token, resetRequest.Password).Result;

            return result.Succeeded ? (Result.Ok().WithSuccess("Senha redefinida com sucesso!")) : (Result.Fail("Erro ao redefinir senha!"));
        }
        private CustomIdentityUser? GetUserByEmail(string email)
        {
            return _signInManager
                .UserManager
                .Users
                .FirstOrDefault(x => x.NormalizedEmail == email.ToUpper());
        }
    }
}
