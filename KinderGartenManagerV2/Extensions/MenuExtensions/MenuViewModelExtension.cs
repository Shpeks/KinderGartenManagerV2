using Core.DTOs.MenuModels;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.MenuEtensions
{
    public static class MenuViewModelExtension
    {
        public static MenuViewModel GetMenuViewModel(this MenuDTO dto)
        {
            var menu = new MenuViewModel
            {
                CountChild = dto.CountChild,
                TypeChild = dto.TypeChild,
                DateCreate = dto.DateCreate,
                FullName = dto.FullName,
            };

            return menu;
        }
    }
}
