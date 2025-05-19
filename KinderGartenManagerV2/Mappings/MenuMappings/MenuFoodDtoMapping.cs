using Core.Models.MenusDto;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Mappings.MenuMappings
{
    public static class MenuFoodDtoMapping
    {
        public static MenuFoodDto GetDto(this MenuFoodViewModel viewModel)
        {
            var menuFood = new MenuFoodDto
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Code = viewModel.Code,
                Count = viewModel.Count,
                CountPerUnit = viewModel.CountPerUnit,
                MealId = viewModel.MealId,
                MealTimeId = viewModel.MealTimeId,
                UnitId = viewModel.UnitId,
                MenuId = viewModel.MenuId
            };

            return menuFood;
        }
    }
}
