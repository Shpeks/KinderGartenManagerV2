using Core.Models.MenusDto;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Mappings.MenuMappings
{
    public static class MenuDtoMapping
    {
        public static MenuDto GetDto(this MenuViewModel viewModel)
        {
            var menu = new MenuDto
            {
                Id = viewModel.Id,
                CountChild = viewModel.CountChild,
                TypeChild = viewModel.TypeChild,
                DateCreate = viewModel.DateCreate,
                FullName = viewModel.FullName,
            };

            return menu;
        }
    }
}
