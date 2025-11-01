using System.Threading.Tasks;
using System.Collections.Generic;
using SportZone_MVC.Models;
using SportZone_MVC.DTOs;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IAuthService
    {
        // ===== AUTHENTICATION METHODS =====

        /// <summary>
        /// Đăng nhập bằng email/password - Trả về LoginResponseDTO cho Cookie Auth
        /// </summary>
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDto);

        /// <summary>
        /// Đăng nhập bằng Google - Vẫn trả về token vì có thể dùng cho external auth
        /// </summary>
        Task<(string token, User user)> GoogleLoginAsync(GoogleLoginDTO googleLoginDto);

        /// <summary>
        /// Đăng xuất user
        /// </summary>
        Task<LogoutResponseDTO> LogoutAsync(LogoutDTO logoutDto);

        // ===== PASSWORD HELPER METHODS =====

        /// <summary>
        /// Hash password sử dụng ASP.NET Core Identity PasswordHasher
        /// </summary>
        string HashPassword(string plainPassword);

        /// <summary>
        /// Xác thực password đã hash
        /// </summary>
        bool VerifyPassword(User user, string plainPassword, string hashedPassword);

        // ===== JWT TOKEN METHODS (Giữ lại cho API/Mobile nếu cần) =====

        /// <summary>
        /// Tạo JWT token cho user (dùng cho API hoặc Google login)
        /// </summary>
        string GenerateJwtToken(User user);

        /// <summary>
        /// Vô hiệu hóa một token cụ thể
        /// </summary>
        Task<bool> InvalidateTokenAsync(string token);

        /// <summary>
        /// Kiểm tra token có hợp lệ không
        /// </summary>
        Task<bool> ValidateTokenAsync(string token);

        // ===== SESSION MANAGEMENT =====

        /// <summary>
        /// Vô hiệu hóa tất cả token/session của một user
        /// </summary>
        Task<bool> InvalidateAllUserTokensAsync(int userId);

        // ===== ROLE HELPER METHODS (Optional - nếu cần) =====

        /// <summary>
        /// Kiểm tra user có role cụ thể không
        /// </summary>
        bool HasRole(User user, AuthService.UserRole requiredRole);

        /// <summary>
        /// Kiểm tra user có phải Admin không
        /// </summary>
        bool IsAdmin(User user);

        /// <summary>
        /// Kiểm tra user có phải Customer không
        /// </summary>
        bool IsCustomer(User user);

        /// <summary>
        /// Kiểm tra user có phải FieldOwner không
        /// </summary>
        bool IsFieldOwner(User user);

        /// <summary>
        /// Kiểm tra user có phải Staff không
        /// </summary>
        bool IsStaff(User user);
    }
}