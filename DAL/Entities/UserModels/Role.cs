using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities.UserModels
{
    public class Role : IdentityRole<string>
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
