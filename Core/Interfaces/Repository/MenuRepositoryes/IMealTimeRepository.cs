using Core.Models.MenusDto;

namespace Core.Interfaces.Repository
{
    public interface IMealTimeRepository
    {
        Task<List<MealTimeDto>> GetAllAsync();
        Task<MealTimeDto> GetByIdAsync(int id);
    }
}