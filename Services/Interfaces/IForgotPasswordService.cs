using SportZone_MVC.DTOs;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IForgotPasswordService
    {
        Task<ServiceResponse<string>> SendCodeAsync(ForgotPasswordDto dto);
        Task<ServiceResponse<string>> ResetPasswordAsync(VerifyCodeDto dto);
    }
}