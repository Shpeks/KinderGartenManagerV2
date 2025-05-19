using Core.Models.MenusDto;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.MenuExtensions
{
    public static class MealTimeViewModelExtension
    {
        public static MealTimeViewModel GetViewModel(this MealTimeDto dTO)
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
