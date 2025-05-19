using Core.Models.MenusDto;

namespace Core.Interfaces.Repository
{
    public interface IMealRepository
    {
        Task<List<MealDto>> GetAllAsync();
        Task<MealDto> GetByIdAsync(int id);
    }
}