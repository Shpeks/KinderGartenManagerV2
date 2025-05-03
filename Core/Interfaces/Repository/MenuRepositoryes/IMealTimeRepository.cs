using Core.DTOs.MenuModels;

namespace Core.Interfaces.Repository
{
    public interface IMealTimeRepository
    {
        Task<List<MealTimeDTO>> GetAllMealTimes();
        Task<MealTimeDTO> GetMealTimeById(int id);
    }
}