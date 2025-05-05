using Core.DTOs.MenuModels;

namespace Core.Interfaces.Serivces
{
    public interface IMenuService
    {
        Task CreateMenuAsync(MenuDTO dto);
    }
}