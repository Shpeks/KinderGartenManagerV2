using Core.Models.MenusDto;
using Core.Interfaces.Repository;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.MenuRepositories
{
    public class MealTimeRepository : IMealTimeRepository
    {
        private readonly ApplicationDbContext _context;
        public MealTimeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MealTimeDto>> GetAllAsync()
        {
            var timeEntity = await _context.MealsTime.ToListAsync();

            return timeEntity.Select(b => new MealTimeDto
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }

        public async Task<MealTimeDto> GetByIdAsync(int id)
        {
            var timeEntity = await _context.MealsTime.FindAsync(id);

            return new MealTimeDto
            {
                Name = timeEntity.Name,
            };
        }
    }
}
