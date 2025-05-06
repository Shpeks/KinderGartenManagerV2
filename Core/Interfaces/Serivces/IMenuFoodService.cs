using Core.DTOs.MenuModels;

namespace Core.Interfaces.Serivces
{
    public interface IMenuFoodService
    {
        Task CreateMenuAsync(MenuFoodDTO dto);
    }
}