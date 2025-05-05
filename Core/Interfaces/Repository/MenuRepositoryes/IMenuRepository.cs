using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IMenuRepository
    {
        Task CreateAsync(MenuDTO menuDTO);
        Task DeleteAsync(int id);
        Task<List<MenuDTO>> GetAllAsync();
        Task<MenuDTO> GetByIdAsync(int id);
        Task UpdateAsync(MenuDTO menuDTO);
    }
}