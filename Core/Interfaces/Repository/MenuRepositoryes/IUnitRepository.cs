using Core.Models.MenusDto;

namespace Core.Interfaces.Repository
{
    public interface IUnitRepository
    {
        Task CreateAsync(UnitDto unitDTO);
        Task DeleteAsync(int id);
        Task<List<UnitDto>> GetAllAsync();
        Task<UnitDto> GetByIdAsync(int id);
        Task UpdateAsync(UnitDto unitDTO);
    }
}