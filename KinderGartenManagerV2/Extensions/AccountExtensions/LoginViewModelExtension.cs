using Core.Models.AccountsDto;
using KinderGartenManagerV2.Models.AccountModels;

namespace KinderGartenManagerV2.Extensions.AccountExtensions
{
    public static class LoginViewModelExtension
    {
        public static LoginViewModel GetViewModel(this LoginDto dto)
        {
            var login = new LoginViewModel
            {
                UserName = dto.UserName,
                Password = dto.Password,
                RememberMe = dto.RememberMe,
            };

            return login;
        }
    }
}
