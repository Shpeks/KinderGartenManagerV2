using Core.Interfaces.Repository;
using DAL.Data;
using DAL.Entities.UserModels;
using DAL.Repository;
using DAL.Repository.MenuRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var conf = builder.Configuration;

// Add services to the container.
services.AddControllersWithViews();

services.AddScoped<IMenuRepository, MenuRepository>();
services.AddScoped<IUserRepository, UserRepository>();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(conf.GetConnectionString("DefaultConnection")));

services.AddIdentity<User, IdentityRole<string>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

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
    pattern: "{controller=Menu}/{action=List}/{id?}");

app.Run();
