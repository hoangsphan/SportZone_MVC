using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportZone_MVC.Repositories;
using SportZone_MVC.Repositories.Interfaces;
using SportZone_MVC.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json.Serialization;
using SportZone_MVC.Models;
using SportZone_MVC.Services.Interfaces;
using SportZone_MVC.Services;
using SportZone_MVC.DTOs;
using SportZone_MVC.Mappings;
using SportZone_MVC.Hubs;

using SportZone_MVC.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyCnn");

// Add services to the container.
// 1. THÊM CONTROLLERS VỚI VIEWS (KHÁC VỚI API)
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

// 2. CẤU HÌNH XÁC THỰC COOKIE (THAY THẾ CHO JWT)
builder.Services.AddAuthentication(options =>
{
    // Đặt Cookie làm phương thức xác thực mặc định
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme; // Thử thách bằng Google nếu cần
})
.AddCookie(options =>
{
    options.LoginPath = "/Auth/Login"; // Trang chuyển hướng khi chưa đăng nhập
    options.AccessDeniedPath = "/Home/AccessDenied"; // Trang khi không có quyền
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
})
.AddGoogle(options => // Giữ nguyên cấu hình Google
{
    options.ClientId = "556790071077-0hk1p2ahlh1vllotj74ih98tbrft3esl.apps.googleusercontent.com";
    options.ClientSecret = "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";
    options.CallbackPath = "/signin-google"; // Callback này phải được xử lý bởi một Controller
    options.SaveTokens = true;
});


// 3. THÊM SIGNALR (GIỮ NGUYÊN)
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Có thể bạn không cần cái này nữa
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// 4. ĐĂNG KÝ DBCONTEXT (GIỮ NGUYÊN)
builder.Services.AddDbContext<SportZoneContext>(options =>
    options.UseSqlServer(connectionString));

// 5. ĐĂNG KÝ AUTOMAPPER (GIỮ NGUYÊN)
builder.Services.AddAutoMapper(typeof(MappingField).Assembly);
builder.Services.AddAutoMapper(typeof(MappingOrder).Assembly);
builder.Services.AddAutoMapper(typeof(MappingBooking).Assembly);

// 6. ĐĂNG KÝ TẤT CẢ SERVICES VÀ REPOSITORIES (SAO CHÉP TỪ API)
builder.Services.AddMemoryCache();
builder.Services.Configure<SendEmail>(builder.Configuration.GetSection("SendEmail"));
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IForgotPasswordService, ForgotPasswordService>();
builder.Services.AddScoped<IForgotPasswordRepository, ForgotPasswordRepository>();
builder.Services.AddScoped<IFacilityService, FacilityService>();
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IFieldService, FieldService>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<IFieldBookingScheduleRepository, FieldBookingScheduleRepository>();
builder.Services.AddScoped<IFieldBookingScheduleService, FieldBookingScheduleService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IFieldPricingRepository, FieldPricingRepository>();
builder.Services.AddScoped<IFieldPricingService, FieldPricingService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, SportZone_MVC.Services.OrderService>();
builder.Services.AddScoped<IOrderFieldIdRepository, OrderFieldIdRepository>();
builder.Services.AddScoped<IOrderFieldIdService, OrderFieldIdService>();
builder.Services.AddScoped<IOrderServiceRepository, OrderServiceRepository>();
builder.Services.AddScoped<IOrderServiceService, OrderServiceService>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ICategoryFieldRepository, CategoryFieldRepository>();
builder.Services.AddScoped<ICategoryFieldService, CategoryFieldService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IRegulationSystemRepository, RegulationSystemRepository>();
builder.Services.AddScoped<IRegulationSystemService, RegulationSystemService>();
builder.Services.AddScoped<IRegulationFacilityRepository, RegulationFacilityRepository>();
builder.Services.AddScoped<IRegulationFacilityService, RegulationFacilityService>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IVNPayService, VNPayService>();
builder.Services.AddHostedService<ScheduleStatusUpdaterService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddHostedService<ReservationCleanupService>();
builder.Services.AddHttpContextAccessor(); // Rất quan trọng để đọc HttpContext trong services

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Cho phép truy cập wwwroot (CSS, JS, Images)

app.UseRouting();
app.UseCors("AllowSpecificOrigin"); // Có thể bỏ nếu không cần thiết

// 7. KÍCH HOẠT XÁC THỰC VÀ PHÂN QUYỀN (RẤT QUAN TRỌNG)
app.UseAuthentication();
app.UseAuthorization();

// 8. CẤU HÌNH ROUTING CHO MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 9. MAP HUB (GIỮ NGUYÊN)
app.MapHub<NotificationHub>("/notificationhub");

app.Run();