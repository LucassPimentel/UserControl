using FluentResults;
using UserControl.Dtos.Requests;

namespace UserControl.Interfaces
{
    public interface ILoginService
    {
        Result LoginUser(LoginRequest loginRequest);
        Result RequireResetPassword(RequireResetPasswordRequest requireResetRequest);
        Result ResetPassword(ResetPassowordRequest requireResetRequest);
    }
}