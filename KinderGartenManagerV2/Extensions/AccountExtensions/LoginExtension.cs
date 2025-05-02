using Core.DTOs.AccountsModels;
using KinderGartenManagerV2.Models.AccountModels;

namespace KinderGartenManagerV2.Extensions.AccountExtensions
{
    public static class LoginExtension
    {
        public static LoginViewModel GetLoginViewModel(this LoginDTO dto)
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
