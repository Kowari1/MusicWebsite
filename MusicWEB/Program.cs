using Microsoft.EntityFrameworkCore;
using MusicWEB.DataAcess.Repositories.IRepository;
using MusicWEB.DataAcess.Repositories;
using MusicWEB.DataAcessData.Data;
using MusicWEB.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IFileServices, FileServices>();
builder.Services.AddTransient<UserValidationService, UserValidationService>();
builder.Services.AddTransient<IMusicSearchService, MusicSearchService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.Name = "UserCookie";
        options.LoginPath = "/Authentication/Login";
        options.LogoutPath = "/Authentication/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;
        options.Cookie.IsEssential = true;
    });

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

app.UseSession();

app.MapControllerRoute(
    name: "logout",
    pattern: "Authentication/Logout",
    defaults: new { controller = "Authentication", action = "Logout" });

app.MapControllerRoute(
    name: "registration",
    pattern: "Registration/CreateUser",
    defaults: new { controller = "Registration", action = "CreateUser" });

app.MapControllerRoute(
    name: "login",
    pattern: "Authentication/Login",
    defaults: new { controller = "Authentication", action = "Login" });

app.MapControllerRoute(
    name: "admin",
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "customer",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "playlist",
    pattern: "Customer/Playlist/{action=Playlist}/{id?}",
    defaults: new { controller = "Playlist" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
