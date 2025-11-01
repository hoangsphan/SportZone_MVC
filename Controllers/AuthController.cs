using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SportZone_MVC.Repository.Interfaces;
using SportZone_MVC.Services.Interfaces;
using SportZone_MVC.DTOs;
using System.Security.Claims;

namespace SportZone_MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRegisterService _registerService;

        public AuthController(IAuthService authService, IRegisterService registerService)
        {
            _authService = authService;
            _registerService = registerService;
        }

        // 1. Action GET: Hiển thị form đăng nhập
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // 2. Action POST: Xử lý thông tin đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO loginDto, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            try
            {
                // 2.1. Gọi AuthService y hệt như API
                var loginResponse = await _authService.LoginAsync(loginDto);

                if (!loginResponse.Flag)
                {
                    ModelState.AddModelError(string.Empty, loginResponse.Message);
                    return View(loginDto);
                }

                // 2.2. TẠO COOKIE (Đây là phần thay thế JWT)
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginResponse.Username ?? "Unknown"),
                    new Claim(ClaimTypes.Email, loginResponse.Email ?? string.Empty),
                    new Claim(ClaimTypes.NameIdentifier, loginResponse.UserID ?? "0"),
                    new Claim(ClaimTypes.Role, loginResponse.RoleId?.ToString() ?? "0")
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Tùy chọn: Ghi nhớ đăng nhập
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
                };

                // 2.3. Đăng nhập người dùng
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // 2.4. Chuyển hướng
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Lỗi đăng nhập: {ex.Message}");
                return View(loginDto);
            }
        }

        // 3. Action Đăng xuất
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}