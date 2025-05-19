using Core.Models.AccountsDto;
using KinderGartenManagerV2.Models.AccountModels;

namespace KinderGartenManagerV2.Mappings.AccountMappings
{
    public static class RegisterDtoMapping
    {
        public static RegisterDto GetDto(this RegisterViewModel viewModel)
        {
            var register = new RegisterDto
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Password = viewModel.Password,
                UserName = viewModel.UserName
            };

            return register;
        }
    }
}
