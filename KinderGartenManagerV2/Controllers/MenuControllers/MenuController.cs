using Core.Interfaces.Repository;
using Core.Interfaces.Serivces;
using KinderGartenManagerV2.Extensions.MenuEtensions;
using KinderGartenManagerV2.Mappings.MenuMappings;
using KinderGartenManagerV2.Models.MenuModels;
using Microsoft.AspNetCore.Mvc;

namespace KinderGartenManagerV2.Controllers.MenuControllers
{
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMenuService _menuService;
        public MenuController(IMenuRepository menuRepository, IMenuService menuService)
        {
            _menuRepository = menuRepository;
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> ListMenu()
        {
            var menuDto = await _menuRepository.GetAllAsync();

            var viewModels = menuDto
                .Select(dto => dto.GetViewModel())
                .ToList();

            return View(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuViewModel viewModel)
        {
            var modelDto = viewModel.GetDto();

            await _menuService.CreateMenuAsync(modelDto);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MenuViewModel viewModel)
        {
            var modelDto = viewModel.GetDto();

            await _menuRepository.UpdateAsync(modelDto);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuRepository.DeleteAsync(id);

            return RedirectToAction("List");
        }
    }
}
