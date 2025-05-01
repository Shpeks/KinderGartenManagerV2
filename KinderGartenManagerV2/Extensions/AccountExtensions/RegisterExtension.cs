using Core.DTOs.AccountsModels;
using Core.DTOs.MenuModels;
using KinderGartenManagerV2.Models.AccountModels;
using KinderGartenManagerV2.Models.MenuModels;

namespace KinderGartenManagerV2.Extensions.AccountExtensions
{
    public static class RegisterExtension
    {
        public static RegisterViewModel GetRegisterViewModel(this RegisterDTO dto)
        {
            var register = new RegisterViewModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                Password = dto.Password,
            };

            return register;
        }
    }
}
