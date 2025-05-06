using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IUnitRepository
    {
        Task CreateAsync(UnitDTO unitDTO);
        Task DeleteAsync(int id);
        Task<List<UnitDTO>> GetAllAsync();
        Task<UnitDTO> GetByIdAsync(int id);
        Task UpdateAsync(UnitDTO unitDTO);
    }
}