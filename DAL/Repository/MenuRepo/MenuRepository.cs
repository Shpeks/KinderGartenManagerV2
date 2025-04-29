using Core.DTOs.MenuModels;
using DAL.Data;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.MenuFolder
{
    public class MenuRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuDTO>> GetAllMenusAsync()
        {
            var menuEntity = await _context.Menus.ToListAsync();

            return menuEntity.Select(m => new MenuDTO
            {
                CountChild = m.CountChild,
                DateCreate = m.DateCreate,
                TypeChild = m.TypeChild,
                UserId = m.UserId,
            }).ToList();
        }

        public async Task<MenuDTO> GetMenuByIdAsync(int id)
        {
            var menuEntity = await _context.Menus.FindAsync(id);
            if (menuEntity == null) return null;

            return new MenuDTO
            {
                CountChild = menuEntity.CountChild,
                DateCreate = menuEntity.DateCreate,
                TypeChild = menuEntity.TypeChild,
                UserId = menuEntity.UserId,
            };
        }

        public async Task MenuUpdateAsync(MenuDTO menuDTO)
        {
            var menuEntity = await _context.Menus.FindAsync(menuDTO.Id);
            if (menuEntity == null) return;

            menuEntity.DateCreate = menuDTO.DateCreate;
            menuEntity.CountChild = menuDTO.CountChild;
            menuEntity.TypeChild = menuDTO.TypeChild;
            menuEntity.UserId = menuDTO.UserId;

            await _context.SaveChangesAsync();
        }

        public async Task CreateMenuAsync(MenuDTO menuDTO)
        {
            var menuEntity = new Menu
            {
                CountChild = menuDTO.CountChild,
                DateCreate = menuDTO.DateCreate,
                TypeChild = menuDTO.TypeChild,
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
