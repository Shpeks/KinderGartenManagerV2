using Core.DTOs.AccountsModels;
using KinderGartenManagerV2.Models.AccountModels;

namespace KinderGartenManagerV2.Mappings.AccountMappings
{
    public static class RegisterToDTO
    {
        public static RegisterDTO GetRegisterDTO(this RegisterViewModel viewModel)
        {
            var register = new RegisterDTO
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
