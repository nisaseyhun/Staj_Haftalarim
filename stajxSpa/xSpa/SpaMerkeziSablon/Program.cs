using System;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity ayarları
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.LoginPath = "/Error/AccessDenied";
    options.AccessDeniedPath = "/Error/AccessDenied";
    options.SlidingExpiration = true;
    options.Cookie.Name = ".SpaMerkezi.Auth";
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// Katmanlı mimari için bağımlılıkları ekle
builder.Services.AddScoped<IBlogDal, EFBlogDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();

builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<ICatagoryDal, EFCatagoryDal>();
builder.Services.AddScoped<ICatagoryService, CatagoryManager>();

builder.Services.AddScoped<IGalaryDal, EFGalaryDal>();
builder.Services.AddScoped<IGalaryService, GalaryManager>();

builder.Services.AddScoped<IHomeDal, EFHomeDal>();
builder.Services.AddScoped<IHomeService, HomeManager>();

builder.Services.AddScoped<ILinkDal, EFLinkDal>();
builder.Services.AddScoped<ILinkService, LinkManager>();

builder.Services.AddScoped<IMessageDal, EFMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<IServiceDal, EFServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

// Yetkilendirme filtreleri
builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = builder.Build();

// Ortam ayarları
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "404-CatchAll",
    pattern: "{*url}",
    defaults: new { controller = "Error", action = "PageNotFound" });

app.Run();
