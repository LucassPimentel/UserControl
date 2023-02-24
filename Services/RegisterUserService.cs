using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Web;
using UserControl.Dtos;
using UserControl.Dtos.Requests;
using UserControl.Interfaces;
using UserControl.Models;

namespace UserControl.Services
{
    public class RegisterUserService : IRegisterUser
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly IEmailService _emailService;

        public RegisterUserService(IMapper mapper, UserManager<CustomIdentityUser> userManager, IEmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public Result ActivateUserAccount(ActivateAccountRequest activateAccountRequest)
        {
            var identityUser = _userManager.Users.FirstOrDefault(x => x.Id == activateAccountRequest.UserId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, activateAccountRequest.ActivationCode).Result;

            return identityResult.Succeeded ? (Result.Ok()) : (Result.Fail("Ocorreu um erro, conta não ativada!"));
        }

        public async Task<Result> RegisterUser(PostUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var identityUser = _mapper.Map<CustomIdentityUser>(user);
            var identityResult = await _userManager.CreateAsync(identityUser, userDto.Password);

            var userRoleResult = await _userManager
                .AddToRoleAsync(identityUser, "Regular");

            if (identityResult.Succeeded)
            {
                var activationCode = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;

                var encodedCode = HttpUtility.UrlEncode(activationCode);

                _emailService.SendEmailToConfirmAccount(new string[] { identityUser.Email }, "link ativacao", identityUser.Id, encodedCode);

                return Result.Ok().WithSuccess(activationCode);
            }
            return Result.Fail(identityResult.ToString());
        }
    }
}
