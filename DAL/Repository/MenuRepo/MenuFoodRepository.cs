using Core.DTOs.MenuModels;
using Core.Interfaces.Repository;
using DAL.Data;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.MenuRepo
{
    public class MenuFoodRepository : IMenuFoodRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuFoodRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MenuFoodDTO>> GetAllAsync()
        {
            var menuFoodEntity = await _context.MenuFoods.ToListAsync();

            return menuFoodEntity.Select(m => new MenuFoodDTO
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

        public async Task<MenuFoodDTO> GetByIdAsync(int id)
        {
            var menuFoodEntity = await _context.MenuFoods.FindAsync(id);
            if (menuFoodEntity == null) return null;

            return new MenuFoodDTO
            {
                Code = menuFoodEntity.Code,
                Count = menuFoodEntity.Count,
                CountPerUnit = menuFoodEntity.CountPerUnit,
                MealId = menuFoodEntity.MealId,
                MealTimeId = menuFoodEntity.MealTimeId,
                MenuId = menuFoodEntity.MenuId,
                Name = menuFoodEntity.Name,
                UnitId = menuFoodEntity.UnitId,
            };
        }

        public async Task UpdateAsync(MenuFoodDTO menuFoodDTO)
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

        public async Task CreateAsync(MenuFoodDTO menuFoodDTO)
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
        }

        public async Task DeleteAsync(int id)
        {
            var menuFoodEntity = await _context.MenuFoods.FindAsync(id);
            if (menuFoodEntity == null) return;

            _context.MenuFoods.Remove(menuFoodEntity);
            await _context.SaveChangesAsync();
        }

    }
}
