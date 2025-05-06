using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IMealTimeRepository
    {
        Task<List<MealTimeDTO>> GetAllAsync();
        Task<MealTimeDTO> GetByIdAsync(int id);
    }
}