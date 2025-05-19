using Core.Models.MenusDto;

namespace Core.Interfaces.Serivces
{
    public interface IMenuFoodService
    {
        Task CreateMenuAsync(MenuFoodDto dto);
    }
}