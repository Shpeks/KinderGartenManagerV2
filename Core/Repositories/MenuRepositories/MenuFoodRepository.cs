using Core.Models.MenusDto;
using Core.Interfaces.Repository;
using DAL.Data;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.MenuRepositories
{
    public class MenuFoodRepository : IMenuFoodRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuFoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MenuFoodDto>> GetAllAsync()
        {
            try
            {
                var menuFoodEntity = await _context.MenuFoods.ToListAsync();

                return menuFoodEntity.Select(m => new MenuFoodDto
                {
                    Code = m.Code,
                    CountPerUnit = m.CountPerUnit,
                    MealId = m.MealId,
                    MealTimeId = m.MealTimeId,
                    Name = m.Name,
                    UnitId = m.UnitId,
                    MenuId = m.MenuId,
                    Count = m.Count,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка", ex);
            }
        }

        public async Task<List<MenuFoodDto>> GetByMenuIdAsync(int id)
        {
            try
            {
                var menuFoodEntity = await _context.MenuFoods
                    .Where(x => x.MenuId == id)
                    .Include(mf => mf.Unit)
                    .Include(mf => mf.Meal)
                    .Include(mf => mf.MealTime)
                    .ToListAsync();

                return menuFoodEntity.Select(x => new MenuFoodDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    CountPerUnit = x.CountPerUnit,
                    Count = x.Count,
                    MealId = x.MealId,
                    MealName = x.Meal.Name,
                    MealTimeId = x.MealTimeId,
                    MealTimeName = x.MealTime.Name,
                    UnitId = x.UnitId,
                    UnitName = x.Unit.Name,
                    MenuId = x.MenuId,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка", ex);
            }
        }

        public async Task UpdateAsync(MenuFoodDto menuFoodDTO)
        {
            try
            {
                var menuFoodEntity = await _context.MenuFoods.FindAsync(menuFoodDTO.Id);
                if (menuFoodEntity == null) return;

                menuFoodEntity.Code = menuFoodDTO.Code;
                menuFoodEntity.Count = menuFoodDTO.Count;
                menuFoodEntity.CountPerUnit = menuFoodDTO.CountPerUnit;
                menuFoodEntity.MealId = menuFoodDTO.MealId;
                menuFoodEntity.MealTimeId = menuFoodDTO.MealTimeId;
                menuFoodEntity.MenuId = menuFoodDTO.MenuId;
                menuFoodEntity.Name = menuFoodDTO.Name;
                menuFoodEntity.UnitId = menuFoodDTO.UnitId;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                throw new ApplicationException("Ошибка при обновлении данных в базе.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка", ex);
            }
        }

        public async Task CreateAsync(MenuFoodDto menuFoodDTO)
        {
            using var tr = _context.Database.BeginTransaction();
            try
            {
                var menuFoodEntity = new MenuFood
                {
                    Code = menuFoodDTO.Code,
                    Count = menuFoodDTO.Count,
                    CountPerUnit = menuFoodDTO.CountPerUnit,
                    MealId = menuFoodDTO.MealId,
                    MealTimeId = menuFoodDTO.MealTimeId,
                    MenuId = menuFoodDTO.MenuId,
                    Name = menuFoodDTO.Name,
                    UnitId = menuFoodDTO.UnitId,
                };

                await _context.AddAsync(menuFoodEntity);
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
            try
            {
                var menuFoodEntity = await _context.MenuFoods.FindAsync(id);
                if (menuFoodEntity == null) return;

                _context.MenuFoods.Remove(menuFoodEntity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка", ex);
            }
        }

    }
}
