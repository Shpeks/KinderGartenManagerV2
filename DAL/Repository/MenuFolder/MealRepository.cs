using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.MenuModels;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.MenuFolder
{
    public class MealRepository
    {
        private readonly ApplicationDbContext _context;
        public MealRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<MealDTO>> GetAllMeals()
        {
            var mealEntity = await _context.Meals.ToListAsync();

            return mealEntity.Select(b => new MealDTO
            {
                Name = b.Name,
            }).ToList();
        }

        public async Task<MealDTO> GetMealById(int id)
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
