using Core.DTOs.AccountsModels;
using Core.Interfaces.Serivces;
using DAL.Entities.UserModels;
using KinderGartenManagerV2.Extensions.AccountExtensions;
using KinderGartenManagerV2.Mappings.AccountMappings;
using KinderGartenManagerV2.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;

namespace KinderGartenManagerV2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userSerice;
        public AccountController(IUserService userService)
        {
            _userSerice = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var modelDto = viewModel.GetRegisterDTO();

            var result = await _userSerice.RegisterAsync(modelDto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return RedirectToAction("HomePage", "Home");
        }
    }
}
