using Microsoft.AspNetCore.Mvc;
using SportZone_MVC.DTOs; // Thêm dòng này
using SportZone_MVC.Services.Interfaces; // Quan trọng
using System.Diagnostics;

namespace SportZone_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFacilityService _facilityService;

        public HomeController(IFacilityService facilityService)
        {
            _facilityService = facilityService;
        }

        // 2. Lấy dữ liệu và truyền cho View (ĐÃ SỬA LỖI)
        public async Task<IActionResult> Index()
        {
            // 1. Lấy toàn bộ đối tượng ServiceResponse
            var serviceResponse = await _facilityService.GetAllFacilities();

            // 2. Chỉ truyền thuộc tính .Data (là List<FacilityDto>) cho View
            // Kiểm tra serviceResponse.Flag nếu cần thiết
            if (serviceResponse.Flag && serviceResponse.Data != null)
            {
                return View(serviceResponse.Data); // <- SỬA Ở ĐÂY
            }

            // Nếu không thành công hoặc không có dữ liệu, trả về 1 danh sách rỗng
            return View(new List<FacilityDto>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Xoá model ErrorViewModel đi nếu bạn đã làm ở Giai đoạn 2
            return View();
        }
    }
}