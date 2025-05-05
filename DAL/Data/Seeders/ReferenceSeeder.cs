using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using DAL.Entities.MenuModels;

namespace DAL.Data.Seeders
{
    public static class ReferenceSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedUnitsAsync(context);
            await SeedMealTimesAsync(context);
            await context.SaveChangesAsync();
        }

        private static async Task SeedUnitsAsync(ApplicationDbContext context)
        {
            if (!context.Units.Any())
            {
                var units = Enum.GetValues(typeof(UnitEnum))
                    .Cast<UnitEnum>()
                    .Select(u => new Unit { Name = u.ToString() });
                
                await context.Units.AddRangeAsync(units);
            }
        }

        private static async Task SeedMealTimesAsync(ApplicationDbContext context)
        {
            if (!context.MealsTime.Any())
            {
                var times = Enum.GetValues(typeof(MealTimeEnum))
                    .Cast<MealTimeEnum>()
                    .Select(u => new MealTime { Name = u.ToString() });

                await context.MealsTime.AddRangeAsync(times);
            }
        }
    }
}
