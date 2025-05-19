using Core.Models.MenusDto;
using Core.Interfaces.Repository;
using DAL.Data;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.MenuRepositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuDto>> GetAllAsync()
        {
            var menuEntity = await _context.Menus
                .Include(m => m.User)
                .ToListAsync();

            return menuEntity.Select(m => new MenuDto
            {
                Id = m.Id,
                CountChild = m.CountChild,
                DateCreate = m.DateCreate,
                TypeChild = m.TypeChild,
                UserId = m.UserId,
                FullName = $"{m.User.LastName} {m.User.FirstName}"
            }).ToList();
        }

        public async Task<MenuDto> GetByIdAsync(int id)
        {
            var menuEntity = await _context.Menus
                .FindAsync(id);
            if (menuEntity == null) return null;

            var user = await _context.Users.FindAsync(menuEntity.UserId);

            return new MenuDto
            {
                CountChild = menuEntity.CountChild,
                DateCreate = menuEntity.DateCreate,
                TypeChild = menuEntity.TypeChild,
                UserId = menuEntity.UserId,
                FullName = $"{user.LastName} {user.FirstName}"
            };
        }

        public async Task UpdateAsync(MenuDto menuDTO)
        {
            var menuEntity = await _context.Menus.FindAsync(menuDTO.Id);
            if (menuEntity == null) return;

            menuEntity.DateCreate = DateTime.SpecifyKind(menuDTO.DateCreate, DateTimeKind.Utc);
            menuEntity.CountChild = menuDTO.CountChild;
            menuEntity.TypeChild = menuDTO.TypeChild;

            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(MenuDto menuDTO)
        {
            using var tr = _context.Database.BeginTransaction();
            try
            {
                var menuEntity = new Menu
                {
                    CountChild = 0,
                    DateCreate = DateTime.UtcNow,
                    TypeChild = "Сад",
                    UserId = menuDTO.UserId,
                };

                await _context.AddAsync(menuEntity);
                await _context.SaveChangesAsync();

                tr.Commit();
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw new ApplicationException("Ошибка", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var menuEntity = await _context.Menus.FindAsync(id);
            if (menuEntity == null) return;

            _context.Menus.Remove(menuEntity);
            await _context.SaveChangesAsync();
        }
    }
}
