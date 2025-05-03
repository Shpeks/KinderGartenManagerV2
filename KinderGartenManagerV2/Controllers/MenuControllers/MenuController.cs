using API.Services;
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
        public async Task<IActionResult> List()
        {
            var menuDto = await _menuRepository.GetAllMenusAsync();

            var viewModels = menuDto
                .Select(dto => dto.GetMenuViewModel())
                .ToList();

            return View("ListMenu", viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuViewModel viewModel)
        {
            var modelDto = viewModel.GetMenuDTO();

            await _menuService.CreateMenuAsync(modelDto);

            return RedirectToAction("List");
        }
    }
}
