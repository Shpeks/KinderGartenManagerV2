using Core;
using Core.Interfaces.Repository;
using Core.Interfaces.Serivces;
using Core.Repositories.MenuRepositories;
using Core.Services;
using DAL.Data;
using DAL.Entities.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var conf = builder.Configuration;

// Add services to the container.
services.AddControllersWithViews();

services.AddTransient<IMenuRepository, MenuRepository>();
services.AddTransient<IMenuFoodRepository, MenuFoodRepository>();
services.AddTransient<IUnitRepository, UnitRepository>();
services.AddTransient<IMealRepository, MealRepository>();
services.AddTransient<IMealTimeRepository, MealTimeRepository>();
services.AddScoped<IMenuFoodService, MenuFoodService>();
services.AddScoped<IMenuService, MenuService>();
services.AddScoped<IUserService, UserService>();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(conf.GetConnectionString("DefaultConnection")));

services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Выполнения DbInit
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    await DbInitializer.SeedAsync(scope.ServiceProvider);
}
//TODO сделать эндпоинты
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
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();
