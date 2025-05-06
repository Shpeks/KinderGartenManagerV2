using Core.Interfaces.Repository;
using Core.Interfaces.Serivces;
using KinderGartenManagerV2.Extensions.MenuEtensions;
using KinderGartenManagerV2.Extensions.MenuExtensions;
using KinderGartenManagerV2.Mappings.MenuMappings;
using KinderGartenManagerV2.Models.MenuModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KinderGartenManagerV2.Controllers.MenuControllers
{
    public class MenuFoodController : Controller
    {
        private readonly IMenuFoodRepository _menuFoodRepository;
        private readonly IMenuFoodService _menuFoodService;
        private readonly IUnitRepository _unitRepository;
        private readonly IMealRepository _mealRepository;
        private readonly IMealTimeRepository _mealTimeRepository;
        public MenuFoodController(
            IMenuFoodRepository menuFoodRepository, 
            IMenuFoodService menuFoodService, 
            IUnitRepository unitRepository, 
            IMealTimeRepository mealTimeRepository, 
            IMealRepository mealRepository)
        {
            _menuFoodRepository = menuFoodRepository;
            _menuFoodService = menuFoodService;
            _unitRepository = unitRepository;
            _mealRepository = mealRepository;
            _mealTimeRepository = mealTimeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List(int id)
        {
            var dto = await _menuFoodRepository.GetByMenuIdAsync(id);

            var viewModel = dto
                .Select(mf => mf.GetMenuFoodViewModel())
                .ToList();

            var unitViewModels = (await _unitRepository.GetAllAsync())
                .Select(u => u.GetUnitViewModel())
                .ToList();

            var mealViewModels = (await _mealRepository.GetAllAsync())
                .Select(m => m.GetMealViewModel())
                .ToList();

            var mealTimeViewModels = (await _mealTimeRepository.GetAllAsync())
                .Select(mt => mt.GetMealTimeViewModel())
                .ToList();

            ViewBag.Units = new SelectList(unitViewModels, "Id", "Name");
            ViewBag.Meals = new SelectList(mealViewModels, "Id", "Name");
            ViewBag.MealTimes = new SelectList(mealTimeViewModels, "Id", "Name");

            ViewBag.MenuId = id;
            

            return View("ListMenuFood", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuFoodViewModel viewModel)
        {
            var dto = viewModel.GetMenuFoodDTO();
            await _menuFoodService.CreateMenuAsync(dto);

            return RedirectToAction("List", new { id = viewModel.MenuId });
        }
    }
}
