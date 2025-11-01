using SportZone_MVC.Models;

namespace SportZone_MVC.Repositories.Interfaces
{
    public interface IForgotPasswordRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task SaveUserAsync();
    }
}