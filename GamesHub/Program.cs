using GamesHub.Infrastructure.DapperRepo;
using GamesHub.Infrastructure.IDapperRepo;
using GamesHub.Infrastructure.IRepo;
using GamesHub.Infrastructure.Repo;
using GamesHub.Model.AppSetting;
using GamesHub.Services.Implementation;
using GamesHub.Services.Interface;
using GamesHUb.Domain.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
AppSettingProvider.JWT = new Jwt()
{
    ValidAudience = configuration["JWT:ValidAudience"],
    ValidIssuer = configuration["JWT:ValidIssuer"],
    Secret = configuration["JWT:Secret"],
    TokenValidityInMinutes = configuration["JWT:TokenValidityInMinutes"],
    RefreshTokenValidityInDays = configuration["JWT:RefreshTokenValidityInDays"],
};
AppSettingProvider.SqlConnectionString = configuration["SqlConnectionString:ConnectionString"];


//Repo 
builder.Services.AddScoped<IUserDapperRep, UserDapperRepo>();
builder.Services.AddScoped<IUserOtpRepo, UserOtpRepo>();
builder.Services.AddScoped<IJWTManagerRepository, JWTManagerRepository>();

//Service
builder.Services.AddScoped<IUserOtpService, UserOtpService>();



builder.Services.AddDbContext<GamesHubContext>(options =>
{
    options.UseSqlServer(AppSettingProvider.SqlConnectionString);
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.Cookie.Name = "UserAuth";
               options.Cookie.HttpOnly = true; // Helps protect against XSS attacks
               options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set cookie expiration time
               options.SlidingExpiration = true; // Renew the cookie expiration time on each request
               options.LoginPath = "/Account/Login"; // Customize login path
               options.LogoutPath = "/Account/Logout"; // Customize logout path
               options.AccessDeniedPath = "/Account/AccessDenied"; // Customize access denied path
           });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
