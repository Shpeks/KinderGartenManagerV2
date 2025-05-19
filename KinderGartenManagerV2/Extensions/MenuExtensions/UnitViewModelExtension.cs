using Core.Models.MenusDto;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.MenuExtensions
{
    public static class UnitViewModelExtension
    {
        public static UnitViewModel GetViewModel(this UnitDto unitDTO)
        {
            var unit = new UnitViewModel
            {
                Id = unitDTO.Id,
                Name = unitDTO.Name,
            };

            return unit;
        }
    }
}
