using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IMealRepository
    {
        Task<List<MealDTO>> GetAllAsync();
        Task<MealDTO> GetByIdAsync(int id);
    }
}