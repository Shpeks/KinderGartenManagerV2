using Core.Interfaces.Serivces;
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var modelDto = viewModel.GetDto();

            var result = await _userSerice.LoginAsync(modelDto);

            return RedirectToAction("HomePage", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var modelDto = viewModel.GetDto();

            var result = await _userSerice.RegisterAsync(modelDto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return RedirectToAction("HomePage", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userSerice.LogoutAsync();

            return RedirectToAction("Login", "Account");
        }
    }
}
