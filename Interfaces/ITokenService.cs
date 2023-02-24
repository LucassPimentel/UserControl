using Microsoft.AspNetCore.Identity;
using UserControl.Models;

namespace UserControl.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser user, string? role);
    }
}