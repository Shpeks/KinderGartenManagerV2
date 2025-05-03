using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IMenuFoodRepository
    {
        Task CreateMenuFoodAsync(MenuFoodDTO menuFoodDTO);
        Task DeleteMenuFoodAsync(int id);
        Task<List<MenuFoodDTO>> GetAllMenuFoodsAsync();
        Task<MenuFoodDTO> GetMenuFoodByIdAsync(int id);
        Task MenuFoodUpdateAsync(MenuFoodDTO menuFoodDTO);
    }
}