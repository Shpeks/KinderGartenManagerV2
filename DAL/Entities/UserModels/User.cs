using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.MenuModels;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.UserModels
{
    public class User : IdentityUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
