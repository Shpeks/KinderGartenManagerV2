using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IMenuFoodRepository
    {
        Task CreateAsync(MenuFoodDTO menuFoodDTO);
        Task DeleteAsync(int id);
        Task<List<MenuFoodDTO>> GetAllAsync();
        Task<List<MenuFoodDTO>> GetByMenuIdAsync(int id);
        Task UpdateAsync(MenuFoodDTO menuFoodDTO);
    }
}