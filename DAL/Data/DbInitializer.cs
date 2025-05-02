using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using DAL.Entities.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            // Создание ролей из enum
            foreach (var role in Enum.GetNames(typeof(RoleEnum)))
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role { Name = role });
                }
            }

            // Создание админа
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
