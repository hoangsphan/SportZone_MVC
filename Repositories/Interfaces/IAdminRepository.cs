using SportZone_MVC.DTOs;
using SportZone_MVC.Models;

namespace SportZone_MVC.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<User>> GetAllAccountAsync();
        Task<List<User>> SearchUsersAsync(SearchUserDto searchDto);
        Task<User> CreateAccountAsync(CreateAccountDto createAccountDto, string hashedPassword);
        Task<bool> IsEmailExistAsync(string email);
    }
}
