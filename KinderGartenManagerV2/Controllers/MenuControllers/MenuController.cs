using Core.Interfaces.Repository;
using KinderGartenManagerV2.Extensions.MenuEtensions;
using Microsoft.AspNetCore.Mvc;

namespace KinderGartenManagerV2.Controllers.MenuControllers
{
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;
        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
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
    }
}
