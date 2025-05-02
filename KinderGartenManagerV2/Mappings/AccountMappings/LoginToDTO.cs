using Core.DTOs.AccountsModels;
using KinderGartenManagerV2.Models.AccountModels;

namespace KinderGartenManagerV2.Mappings.AccountMappings
{
    public static class LoginToDTO
    {
        public static LoginDTO GetLoginDTO(this LoginViewModel viewModel)
        {
            var login = new LoginDTO
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                RememberMe = viewModel.RememberMe,
            };

            return login;
        }
    }
}
