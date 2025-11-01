using System.Collections.Generic;
using System.Threading.Tasks;
using SportZone_MVC.Models;
using SportZone_MVC.DTOs;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IStaffService
    {
        Task<ServiceResponse<IEnumerable<StaffDto>>> GetAllStaffAsync();
        Task<ServiceResponse<IEnumerable<StaffDto>>> GetStaffByFacilityIdAsync(int facilityId);
        Task<ServiceResponse<StaffDto>> GetStaffByUIdAsync(int uId);
        Task<ServiceResponse<string>> UpdateStaffAsync(int uId, UpdateStaffDto dto);
        Task<ServiceResponse<string>> DeleteStaffAsync(int uId);
        Task<ServiceResponse<List<Staff>>> GetStaffByFieldOwnerIdAsync(int fieldOwnerId);
    }
}