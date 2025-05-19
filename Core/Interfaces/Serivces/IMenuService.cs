using Core.Models.MenusDto;

namespace Core.Interfaces.Serivces
{
    public interface IMenuService
    {
        Task CreateMenuAsync(MenuDto dto);
    }
}