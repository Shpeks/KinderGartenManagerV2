using DAL.Entities.MenuModels;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.UserModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
