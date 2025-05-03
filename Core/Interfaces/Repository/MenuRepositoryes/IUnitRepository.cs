using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IUnitRepository
    {
        Task CreateUnitAsync(UnitDTO unitDTO);
        Task DeleteUnitAsync(int id);
        Task<List<UnitDTO>> GetAllUnitsAsync();
        Task<UnitDTO> GetUnitByIdAsync(int id);
        Task UnitUpdateAsync(UnitDTO unitDTO);
    }
}