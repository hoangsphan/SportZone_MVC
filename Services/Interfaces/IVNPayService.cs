using SportZone_MVC.DTOs;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IVNPayService
    {
        Task<ServiceResponse<VNPayResponseDto>> CreatePaymentUrl(VNPayRequestDto request);
        Task<ServiceResponse<bool>> VerifyPaymentReturn(VNPayReturnDto returnData);
        string CreatePaymentUrl(VNPayRequestDto request, string ipAddress);
        bool VerifyPaymentReturn(VNPayReturnDto returnData, string ipAddress);
    }
} 