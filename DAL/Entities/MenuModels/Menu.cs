using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.MenuModels
{
    public class Menu
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Ясли/Сад
        /// </summary>
        public string TypeChild { get; set; }

        public int CountChild { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    
        public ICollection<MenuFood> MenuFoods { get; set; }
    }
}
