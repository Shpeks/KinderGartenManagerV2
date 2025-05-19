using Core.Models.MenusDto;
using Core.Interfaces.Repository;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.MenuRepositories
{
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _context;
        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MealDto>> GetAllAsync()
        {
            try
            {
                var mealEntity = await _context.Meals.ToListAsync();

                return mealEntity.Select(b => new MealDto
                {
                    Id = b.Id,
                    Name = b.Name,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ошибка", ex);
            }
        }

        public async Task<MealDto> GetByIdAsync(int id)
        {
            try
            {
                var mealEntity = await _context.Meals.FindAsync(id);

                return new MealDto
                {
                    Name = mealEntity.Name,
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Ошибка с {id}", ex);
            }
        }
    }
}
