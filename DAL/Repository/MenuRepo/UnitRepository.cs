using Core.DTOs.MenuModels;
using Core.Interfaces.Repository;
using DAL.Data;
using DAL.Entities.MenuModels;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.MenuRepo
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _context;
        public UnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UnitDTO>> GetAllUnitsAsync()
        {
            var unitEntity = await _context.Units.ToListAsync();

            return unitEntity.Select(m => new UnitDTO
            {
                Name = m.Name,
            }).ToList();
        }

        public async Task<UnitDTO> GetUnitByIdAsync(int id)
        {
            var unitEntity = await _context.Units.FindAsync(id);
            if (unitEntity == null) return null;

            return new UnitDTO
            {
                Name = unitEntity.Name,
            };
        }

        public async Task UnitUpdateAsync(UnitDTO unitDTO)
        {
            var unitEntity = await _context.Units.FindAsync(unitDTO.Id);
            if (unitEntity == null) return;

            unitEntity.Name = unitDTO.Name;

            await _context.SaveChangesAsync();
        }

        public async Task CreateUnitAsync(UnitDTO unitDTO)
        {
            var unitEntity = new Unit
            {
                Name = unitDTO.Name,
            };

            await _context.AddAsync(unitEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUnitAsync(int id)
        {
            var unitEntity = await _context.Units.FindAsync(id);
            if (unitEntity == null) return;

            _context.Units.Remove(unitEntity);
            await _context.SaveChangesAsync();
        }

    }
}
