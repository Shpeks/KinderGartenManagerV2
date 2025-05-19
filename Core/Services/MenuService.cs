using System.Security.Claims;
using Core.Models.MenusDto;
using Core.Interfaces.Repository;
using Core.Interfaces.Serivces;
using Microsoft.AspNetCore.Http;

namespace Core.Services
{
    public class MenuService : IMenuService
    {
        private IMenuRepository _menuRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public MenuService(IMenuRepository menuRepository, IHttpContextAccessor httpContextAccessor)
        {
            _menuRepository = menuRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateMenuAsync(MenuDto dto)
        {
            var userId = _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                throw new UnauthorizedAccessException("Пользователь не авторизирован.");

            dto.UserId = userId;

            await _menuRepository.CreateAsync(dto);
        }
    }
}
