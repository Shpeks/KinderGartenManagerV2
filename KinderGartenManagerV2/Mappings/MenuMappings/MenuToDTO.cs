using Core.DTOs.MenuModels;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Mappings.MenuMappings
{
    public static class MenuToDTO
    {
        public static MenuDTO GetMenuDTO(this MenuViewModel viewModel)
        {
            var menu = new MenuDTO()
            {
                CountChild = viewModel.CountChild,
                TypeChild = viewModel.TypeChild,
                DateCreate = viewModel.DateCreate,
                
            };

            return menu;
        }
    }
}
