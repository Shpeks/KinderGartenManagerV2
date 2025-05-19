using Core.Models.MenusDto;

namespace Core.Interfaces.Repository
{
    public interface IMenuFoodRepository
    {
        Task CreateAsync(MenuFoodDto menuFoodDTO);
        Task DeleteAsync(int id);
        Task<List<MenuFoodDto>> GetAllAsync();
        Task<List<MenuFoodDto>> GetByMenuIdAsync(int id);
        Task UpdateAsync(MenuFoodDto menuFoodDTO);
    }
}