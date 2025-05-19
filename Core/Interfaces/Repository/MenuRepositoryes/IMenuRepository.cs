using Core.Models.MenusDto;

namespace Core.Interfaces.Repository
{
    public interface IMenuRepository
    {
        Task CreateAsync(MenuDto menuDTO);
        Task DeleteAsync(int id);
        Task<List<MenuDto>> GetAllAsync();
        Task<MenuDto> GetByIdAsync(int id);
        Task UpdateAsync(MenuDto menuDTO);
    }
}