using SportZone_MVC.Models;
using SportZone_MVC.DTOs;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IServiceService
    {
        // Lấy tất cả Services
        Task<IEnumerable<ServiceDTO>> GetAllServicesAsync();

        // Lấy Service theo ID với thông tin chi tiết
        Task<ServiceResponseDTO?> GetServiceByIdAsync(int serviceId);

        // Lấy Services theo Facility ID
        Task<IEnumerable<ServiceDTO>> GetServicesByFacilityIdAsync(int facilityId);

        // Lấy Services theo trạng thái
        Task<IEnumerable<ServiceDTO>> GetServicesByStatusAsync(string status);

        // Tạo Service mới
        Task<ServiceResponseDTO> CreateServiceAsync(CreateServiceDTO createServiceDto);

        // Cập nhật Service
        Task<ServiceResponseDTO?> UpdateServiceAsync(int serviceId, UpdateServiceDTO updateServiceDto);

        // Xóa Service
        Task<bool> DeleteServiceAsync(int serviceId);

        // Kiểm tra Service có tồn tại theo ID
        Task<bool> ServiceExistsByIdAsync(int serviceId);

        // Lấy Services với phân trang
        Task<(IEnumerable<ServiceDTO> Services, int TotalCount)> GetServicesWithPaginationAsync(int pageNumber, int pageSize);
    }
}
