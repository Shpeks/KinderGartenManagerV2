using Core.DTOs.MenuModels;
using Core.Interfaces.Repository;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.MenuRepo
{
    public class MealTimeRepository : IMealTimeRepository
    {
        private readonly ApplicationDbContext _context;
        public MealTimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MealTimeDTO>> GetAllMealTimes()
        {
            var timeEntity = await _context.MealsTime.ToListAsync();

            return timeEntity.Select(b => new MealTimeDTO
            {
                Name = b.Name,
            }).ToList();
        }

        public async Task<MealTimeDTO> GetMealTimeById(int id)
        {
            var timeEntity = await _context.MealsTime.FindAsync(id);
            if (timeEntity == null) return null;

            return new MealTimeDTO
            {
                Name = timeEntity.Name,
            };
        }
    }
}
