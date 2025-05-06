using Core.DTOs.MenuModels;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.MenuEtensions
{
    public static class MenuFoodViewModelExtension
    {
        public static MenuFoodViewModel GetMenuFoodViewModel(this MenuFoodDTO dto)
        {
            var model = new MenuFoodViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code,
                Count = dto.Count,
                CountPerUnit = dto.CountPerUnit,
                MealName = dto.MealName,
                MealTimeName = dto.MealTimeName,
                UnitName = dto.UnitName,
            };

            return model;
        }
    }
}
