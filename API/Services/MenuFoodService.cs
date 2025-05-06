using Core.DTOs.MenuModels;
using Core.Interfaces.Repository;
using Core.Interfaces.Serivces;

namespace API.Services
{
    public class MenuFoodService : IMenuFoodService
    {
        private readonly IMenuFoodRepository _menuFoodRepository;
        private readonly IMenuRepository _menuRepository;
        public MenuFoodService(IMenuFoodRepository menuFoodRepository, IMenuRepository menuRepository)
        {
            _menuFoodRepository = menuFoodRepository;
            _menuRepository = menuRepository;
        }
        public async Task CreateMenuAsync(MenuFoodDTO dto)
        {
            var menu = await _menuRepository.GetByIdAsync(dto.MenuId);

            dto.Count = dto.CountPerUnit * menu.CountChild;

            await _menuFoodRepository.CreateAsync(dto);
        }
    }
}
