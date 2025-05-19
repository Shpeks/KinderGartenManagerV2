using Core.Enums;
using DAL.Entities.UserModels;
using Microsoft.AspNetCore.Identity;

namespace Core.Seeders
{
    public static class AdminSeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@mail.ru",
                    FirstName = "admin",
                    LastName = "super"
                };

                var result = await userManager.CreateAsync(admin, "Pa$$word123");

                await userManager.AddToRoleAsync(admin, RoleEnum.Admin.ToString());
            }
        }
    }
}
