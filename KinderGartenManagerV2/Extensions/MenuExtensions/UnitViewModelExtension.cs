using Core.DTOs.MenuModels;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.MenuExtensions
{
    public static class UnitViewModelExtension
    {
        public static UnitViewModel GetUnitViewModel(this UnitDTO unitDTO)
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
