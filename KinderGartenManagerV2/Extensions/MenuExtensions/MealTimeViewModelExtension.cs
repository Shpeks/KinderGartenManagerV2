using Core.DTOs.MenuModels;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.MenuExtensions
{
    public static class MealTimeViewModelExtension
    {
        public static MealTimeViewModel GetMealTimeViewModel(this MealTimeDTO dTO)
        {
            var mt = new MealTimeViewModel
            {
                Id = dTO.Id,
                Name = dTO.Name,
            };

            return mt;
        }
    }
}
