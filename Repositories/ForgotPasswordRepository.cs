using Microsoft.EntityFrameworkCore;
using SportZone_MVC.Models;
using SportZone_MVC.Repositories.Interfaces;

namespace SportZone_MVC.Repositories
{
    public class ForgotPasswordRepository : IForgotPasswordRepository
    {
        private readonly SportZoneContext _context;

        public ForgotPasswordRepository(SportZoneContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UEmail == email);
        }

        public async Task SaveUserAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}