using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IMenuRepository
    {
        Task CreateMenuAsync(MenuDTO menuDTO);
        Task DeleteMenuAsync(int id);
        Task<List<MenuDTO>> GetAllMenusAsync();
        Task<MenuDTO> GetMenuByIdAsync(int id);
        Task MenuUpdateAsync(MenuDTO menuDTO);
    }
}