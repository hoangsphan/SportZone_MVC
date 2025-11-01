using SportZone_MVC.Models;
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace SportZone_MVC.Repositories.Interfaces
{
    public interface ICategoryFieldRepository
    {
        Task<CategoryField?> GetByIdAsync(int id);
        Task<IEnumerable<CategoryField>> GetAllAsync(); 
    }
}