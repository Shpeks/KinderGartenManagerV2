using Core.Enums;
using DAL.Data;
using DAL.Entities.MenuModels;

namespace Core.Seeders
{
    public static class ReferenceSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await SeedUnitsAsync(context);
            await SeedMealTimesAsync(context);
            await context.SaveChangesAsync();
        }
        // TODO: переделать алгоритм добаления. Сейчас не будут добавляться новые записи в таблицу если есть хоть какие то
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
