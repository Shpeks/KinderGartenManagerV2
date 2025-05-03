using Core.DTOs.MenuModels;
using Core.Interfaces.Repository;
using DAL.Data;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.MenuRepo
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuDTO>> GetAllMenusAsync()
        {
            var menuEntity = await _context.Menus
                .Include(m => m.User)
                .ToListAsync();

            return menuEntity.Select(m => new MenuDTO
            {
                CountChild = m.CountChild,
                DateCreate = m.DateCreate,
                TypeChild = m.TypeChild,
                UserId = m.UserId,
                FullName = $"{m.User.LastName} {m.User.FirstName}"
            }).ToList();
        }

        public async Task<MenuDTO> GetMenuByIdAsync(int id)
        {
            var menuEntity = await _context.Menus
                .FindAsync(id);
            if (menuEntity == null) return null;
            var user = await _context.Users.FindAsync(menuEntity.UserId);

            return new MenuDTO
            {
                CountChild = menuEntity.CountChild,
                DateCreate = menuEntity.DateCreate,
                TypeChild = menuEntity.TypeChild,
                UserId = menuEntity.UserId,
                FullName = $"{user.LastName} {user.FirstName}"
            };
        }

        public async Task MenuUpdateAsync(MenuDTO menuDTO)
        {
            var menuEntity = await _context.Menus.FindAsync(menuDTO.Id);
            if (menuEntity == null) return;

            menuEntity.DateCreate = menuDTO.DateCreate;
            menuEntity.CountChild = menuDTO.CountChild;
            menuEntity.TypeChild = menuDTO.TypeChild;

            await _context.SaveChangesAsync();
        }

        public async Task CreateMenuAsync(MenuDTO menuDTO)
        {
            var menuEntity = new Menu
            {
                CountChild = 0,
                DateCreate = DateTime.MinValue,
                TypeChild = "Сад",
                UserId = menuDTO.UserId,
            };

            await _context.AddAsync(menuEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(int id)
        {
            var menuEntity = await _context.Menus.FindAsync(id);
            if (menuEntity == null) return;

            _context.Menus.Remove(menuEntity);
            await _context.SaveChangesAsync();
        }
    }
}
