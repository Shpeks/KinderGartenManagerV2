using System.Security.Claims;
using Core.DTOs.MenuModels;
using Core.Interfaces.Repository;
using Core.Interfaces.Serivces;
using Microsoft.AspNetCore.Http;

namespace API.Services
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

        public async Task CreateMenuAsync(MenuDTO dto)
        {
            var userId = _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                throw new UnauthorizedAccessException("User is not logged in.");

            dto.UserId = userId;

            await _menuRepository.CreateAsync(dto);
        }
    }
}
