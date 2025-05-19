using Core.Models.AccountsDto;
using KinderGartenManagerV2.Models.AccountModels;

namespace KinderGartenManagerV2.Mappings.AccountMappings
{
    public static class LoginDtoMapping
    {
        public static LoginDto GetDto(this LoginViewModel viewModel)
        {
            var login = new LoginDto
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                RememberMe = viewModel.RememberMe,
            };

            return login;
        }
    }
}
