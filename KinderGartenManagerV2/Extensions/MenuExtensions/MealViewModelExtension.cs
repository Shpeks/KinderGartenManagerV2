using Core.Models.MenusDto;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.MenuExtensions
{
    public static class MealViewModelExtension
    {
        public static MealViewModel GetViewModel(this MealDto dto)
        {
            var meal = new MealViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
            };

            return meal;
        }
    }
}
