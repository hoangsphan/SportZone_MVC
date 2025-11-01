using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<User>> GetAllAccount();
        Task<List<User>> SearchUsers(SearchUserDto searchDto);
        Task<User> CreateAccount(CreateAccountDto createAccountDto);
    }
}
