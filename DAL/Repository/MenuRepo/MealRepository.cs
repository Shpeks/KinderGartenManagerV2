using Core.DTOs.MenuModels;
using Core.Interfaces.Repository;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.MenuRepo
{
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;
        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MealDTO>> GetAllAsync()
        {
            var mealEntity = await _context.Meals.ToListAsync();

            return mealEntity.Select(b => new MealDTO
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }

        public async Task<MealDTO> GetByIdAsync(int id)
        {
            var mealEntity = await _context.Meals.FindAsync(id);
            if (mealEntity == null) return null;

            return new MealDTO
            {
                Name = mealEntity.Name,
            };
        }

    }
}
