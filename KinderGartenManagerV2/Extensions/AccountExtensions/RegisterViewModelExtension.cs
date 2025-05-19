using Core.Models.AccountsDto;
using KinderGartenManagerV2.Models.AccountModels;

namespace KinderGartenManagerV2.Extensions.AccountExtensions
{
    public static class RegisterViewModelExtension
    {
        public static RegisterViewModel GetViewModel(this RegisterDto dto)
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
