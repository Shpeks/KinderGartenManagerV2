using Core.Models.MenusDto;
using Core.Interfaces.Repository;
using DAL.Data;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.MenuRepositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _context;
        public UnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UnitDto>> GetAllAsync()
        {
            var unitEntity = await _context.Units.ToListAsync();

            return unitEntity.Select(m => new UnitDto
            {
                Id = m.Id,
                Name = m.Name,
            }).ToList();
        }

        public async Task<UnitDto> GetByIdAsync(int id)
        {
            var unitEntity = await _context.Units.FindAsync(id);
            if (unitEntity == null) return null;

            return new UnitDto
            {
                Name = unitEntity.Name,
            };
        }

        public async Task UpdateAsync(UnitDto unitDTO)
        {
            var unitEntity = await _context.Units.FindAsync(unitDTO.Id);
            if (unitEntity == null) return;

            unitEntity.Name = unitDTO.Name;

            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(UnitDto unitDTO)
        {
            var unitEntity = new Unit
            {
                Name = unitDTO.Name,
            };

            await _context.AddAsync(unitEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var unitEntity = await _context.Units.FindAsync(id);
            if (unitEntity == null) return;

            _context.Units.Remove(unitEntity);
            await _context.SaveChangesAsync();
        }

    }
}
