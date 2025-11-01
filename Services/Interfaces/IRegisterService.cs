using SportZone_MVC.DTOs;
using System.Threading.Tasks;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IRegisterService
    {
        Task<ServiceResponse<string>> RegisterUserAsync(RegisterDto dto);
    }
}